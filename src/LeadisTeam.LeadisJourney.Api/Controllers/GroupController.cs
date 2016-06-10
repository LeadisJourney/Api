using System.Collections.Generic;
using LeadisTeam.LeadisJourney.Api.Models;
using LeadisTeam.LeadisJourney.Core.Repositories;
using LeadisTeam.LeadisJourney.Services.Contracts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace LeadisTeam.LeadisJourney.Api.Controllers
{
    [EnableCors("AllowAll")]
    [Route("v0.1/api/[controller]")]
    public class GroupController : Controller {
        private readonly IGroupService _groupService;
        private readonly IUnitOfWork _unitOfWork;

        public GroupController(IGroupService groupService, IUnitOfWork unitOfWork) {
            _groupService = groupService;
            _unitOfWork = unitOfWork;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/group
        [HttpPost]
        public OkResult Create([FromBody]CreateGroupModel res) {
            _groupService.Create(res.Name, 1);
            _unitOfWork.Commit();
            return Ok();
        }

        // PUT api/group/add/5
        [HttpPut("add/{id}")]
        public OkResult AddUser(int id, [FromBody]AddUserToGroupModel res) {
            _groupService.AddUser(res.accountsId, id);
            _unitOfWork.Commit();
            return Ok();
        }

        // PUT api/group/delete/5
        [HttpPut("delete/{id}")]
        public OkResult DeleteUser(int id, [FromBody]DeleteUserFromGroupModel res) {
            _groupService.DeleteUser(res.accountsId, id);
            _unitOfWork.Commit();
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
