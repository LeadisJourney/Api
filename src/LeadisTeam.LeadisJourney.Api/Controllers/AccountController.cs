using System;
using LeadisTeam.LeadisJourney.Api.Models;
using LeadisTeam.LeadisJourney.Core.Repositories;
using LeadisTeam.LeadisJourney.Services.Contracts;
using Microsoft.AspNet.Mvc;


namespace LeadisTeam.LeadisJourney.Api.Controllers {
    [Route("api/[controller]")]
    public class AccountController : Controller {
        private readonly IAccountService _accountService;
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(IAccountService accountService, IUnitOfWork unitOfWork) {
            _accountService = accountService;
            _unitOfWork = unitOfWork;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id) {
            _accountService.Get(id);
            return "Je suis un account";
        }

        [HttpPost, Route("login")]
        public HttpOkResult Login([FromBody] LoginAccountModel res) {
            throw new NotImplementedException();
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

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Desactivate(int id) {
            throw new NotImplementedException();
        }
    }
}
