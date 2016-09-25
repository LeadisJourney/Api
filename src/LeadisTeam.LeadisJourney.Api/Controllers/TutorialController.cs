using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using LeadisTeam.LeadisJourney.Api.Models;
using LeadisTeam.LeadisJourney.Core.Entities;
using LeadisTeam.LeadisJourney.Repositories.NHibernate;
using LeadisTeam.LeadisJourney.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace LeadisTeam.LeadisJourney.Api.Controllers {
    [EnableCors("AllowAll")]
    [Authorize("Bearer")]
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

        [HttpPost]
        public OkResult Create([FromBody] CreateTutorialModel res)
        {
            _tutorialService.Create(res.Title, res.Sources.Select(s => new TutorialSource
            {
                Content = s.Content,
                Type = s.Type
            }), res.Type, res.ExerciceId);
            return Ok();
        }
        // Création, Modification et Suppression 

    }
}
