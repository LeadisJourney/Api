using System;
using LeadisTeam.LeadisJourney.Api.Models;
using LeadisTeam.LeadisJourney.Api.Security;
using LeadisTeam.LeadisJourney.Repositories.NHibernate;
using LeadisTeam.LeadisJourney.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace LeadisTeam.LeadisJourney.Api.Controllers {
    [EnableCors("AllowAll")]
    [Route("v0.1/api/[controller]")]
    public class AccountController : ApiController {
        private readonly IAccountService _accountService;
        private readonly Authenticator _authenticator;

        public AccountController(IScopeFactory scopeFactory, 
            IAccountService accountService, 
            Authenticator authenticator) 
            : base(scopeFactory) {
            _accountService = accountService;
            _authenticator = authenticator;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ViewAccountModel Get(int id) {
            var account = _accountService.Get(id);
            return new ViewAccountModel() {
                Email = account.Email,
                Name = account.User.Name,
                FirstName = account.User.FirstName,
                Pseudo = account.Pseudo
            };
        }

        [HttpPost, Route("login")]
        public LoginAccountModel.Response Login([FromBody] LoginAccountModel res)
        {
            var user = _accountService.SignIn(res.Email, res.Password);
            if (user != null) {
                var token = _authenticator.GetToken(user, DateTime.UtcNow.AddYears(1));
                return new LoginAccountModel.Response {
                    Token = token
                };
            }
            return null;
        }

        [HttpPost, Route("token")]
        [Authorize("Bearer")]
        public object IsValidToken([FromBody] ValidTokenModel res) {
            if (_authenticator.IsValidToken(res.Token)) {
                return Ok();
            }
            throw new UnauthorizedAccessException();
        }

        // POST api/account/
        [HttpPost]
        public OkResult Create([FromBody] CreateAccountModel res) {
            _accountService.Create(res.Pseudo, res.Email, res.Name, res.FirstName, res.Password);
            return Ok();
        }

        // PUT api/account/5
        [HttpPut("{id}")]
        [Authorize("Bearer")]
        public OkResult Update(int id, [FromBody] UpdateAccountModel res) {
            _accountService.Update(id, res.Email, res.FirstName, res.Name, res.Password);
            return Ok();
        }

        // DELETE api/account/5
        [HttpDelete("{id}")]
        [Authorize("Bearer")]
        public OkResult Desactivate(int id) {
            _accountService.Desactivate(id);
            return Ok();
        }
    }
}
