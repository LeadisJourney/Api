using System.Collections.Generic;
using LeadisTeam.LeadisJourney.Repositories.NHibernate;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace LeadisTeam.LeadisJourney.Api.Controllers {
    [EnableCors("AllowAll")]
    [Route("v0.1/api/[controller]")]
    public class TutorialController : ApiController {
        public TutorialController(IScopeFactory scopeFactory) : base(scopeFactory) {
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get() {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id) {
            return "value";
        }

        // Création, Modification et Suppression du côté ADMIN uniquement

    }
}
