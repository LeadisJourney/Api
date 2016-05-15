using System;
using LeadisTeam.LeadisJourney.Api.Models;
using LeadisTeam.LeadisJourney.Api.Security;
using LeadisTeam.LeadisJourney.Core.Repositories;
using LeadisTeam.LeadisJourney.Services.Contracts;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Cors;
using Microsoft.AspNet.Mvc;


namespace LeadisTeam.LeadisJourney.Api.Controllers {
    [EnableCors("AllowAll")]
    [Route("v0.1/api/[controller]")]
    public class AccountController : Controller {
        private readonly IAccountService _accountService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Authenticator _authenticator;

        public AccountController(IAccountService accountService, IUnitOfWork unitOfWork, Authenticator authenticator) {
            _accountService = accountService;
            _unitOfWork = unitOfWork;
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
        public LoginAccountModel.Response Login([FromBody] LoginAccountModel res) {
            if (res.Email.Equals("user") && res.Password.Equals("pwd")) {
                var token = _authenticator.GetToken(res.Email, DateTime.UtcNow.AddYears(1));
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
        public HttpOkResult Create([FromBody] CreateAccountModel res) {
            _accountService.Create(res.Pseudo, res.Email, res.Name, res.FirstName, res.Password);
            _unitOfWork.Commit();
            return Ok();
        }

        // PUT api/account/5
        [HttpPut("{id}")]
        public HttpOkResult Update(int id, [FromBody] UpdateAccountModel res) {
            _accountService.Update(id, res.Email, res.FirstName, res.Name, res.Password);
            _unitOfWork.Commit();
            return Ok();
        }

        // DELETE api/account/5
        [HttpDelete("{id}")]
        public HttpOkResult Desactivate(int id) {
            _accountService.Desactivate(id);
            _unitOfWork.Commit();
            return Ok();
        }
    }
}
