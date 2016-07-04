using System.Collections.Generic;
using LeadisTeam.LeadisJourney.Api.Models;
using LeadisTeam.LeadisJourney.Repositories.NHibernate;
using LeadisTeam.LeadisJourney.Services.Contracts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace LeadisTeam.LeadisJourney.Api.Controllers
{
    [EnableCors("AllowAll")]
    [Route("v0.1/api/[controller]")]
    public class GroupController : ApiController {
        private readonly IGroupService _groupService;

        public GroupController(IScopeFactory scopeFactory, IGroupService groupService) 
            : base(scopeFactory) {
            _groupService = groupService;
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
            return Ok();
        }

        // PUT api/group/add/5
        [HttpPut("add/{id}")]
        public OkResult AddUser(int id, [FromBody]AddUserToGroupModel res) {
            _groupService.AddUser(res.accountsId, id);
            return Ok();
        }

        // PUT api/group/delete/5
        [HttpPut("delete/{id}")]
        public OkResult DeleteUser(int id, [FromBody]DeleteUserFromGroupModel res) {
            _groupService.DeleteUser(res.accountsId, id);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
