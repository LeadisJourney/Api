using System.Collections.Generic;
using System.Linq;
using LeadisTeam.LeadisJourney.Api.Models;
using LeadisTeam.LeadisJourney.Repositories.NHibernate;
using LeadisTeam.LeadisJourney.Services.Contracts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace LeadisTeam.LeadisJourney.Api.Controllers {
    [EnableCors("AllowAll")]
    [Route("v0.1/api/[controller]")]
    public class TutorialController : ApiController
    {
        private readonly ITutorialService _tutorialService;
        public TutorialController(IScopeFactory scopeFactory, ITutorialService tutorialService) : base(scopeFactory)
        {
            _tutorialService = tutorialService;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<ViewTutorialsModel> Get()
        {
            return _tutorialService.GetAll().Select(t => new ViewTutorialsModel
            {
                Id = t.Id,
                Title = t.Title,
                Sources = t.Sources.Select(s => new TutorialSourceModel
                {
                    Content = s.Content,
                    Type = s.Type
                })
            });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ViewTutorialsModel Get(int id)
        {
            var tuto = _tutorialService.GetById(id);
            return new ViewTutorialsModel
            {
                Id = tuto.Id,
                Title = tuto.Title,
                Sources = tuto.Sources.Select(s => new TutorialSourceModel
                {
                    Content = s.Content,
                    Type = s.Type
                })
            };
        }

        // Création, Modification et Suppression du côté ADMIN uniquement

    }
}
