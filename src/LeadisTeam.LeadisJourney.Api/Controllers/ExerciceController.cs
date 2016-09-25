using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeadisTeam.LeadisJourney.Api.Models;
using LeadisTeam.LeadisJourney.Core.Entities;
using LeadisTeam.LeadisJourney.Core.Repositories;
using LeadisTeam.LeadisJourney.Repositories.NHibernate;
using LeadisTeam.LeadisJourney.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LeadisTeam.LeadisJourney.Api.Controllers
{
    [EnableCors("AllowAll")]
    [Authorize("Bearer")]
    [Route("v0.1/api/[controller]")]
    public class ExerciceController : ApiController
    {
        private readonly IExerciceService _exerciceService;
        public ExerciceController(IScopeFactory scopeFactory, IExerciceService exerciceService) : base(scopeFactory)
        {
            _exerciceService = exerciceService;
        }

        [HttpPost]
        public OkResult Create([FromBody] CreateExerciceModel res)
        {
            _exerciceService.Create(res.Title, res.Position, res.Sources.Select(s => new ExerciceSource
            {
                Type = s.Type,
                Content = s.Content
            }));
            return Ok();
        }

        [HttpGet]
        public IEnumerable<ViewExercicesModel> GetAll()
        {
            return _exerciceService.GetAll().Select(s => new ViewExercicesModel
            {
                Title = s.Title,
                Id = s.Id,
                Position = s.Position,
                Sources = s.Sources.Select(c => new ExerciceSourceModel
                {
                    Type = c.Type,
                    Content = c.Content
                })
            });
        }

        [HttpGet("{id}")]
        public ViewExercicesModel Get(int id)
        {
            var exo = _exerciceService.GetById(id);
            return new ViewExercicesModel
            {
                Id = exo.Id,
                Title = exo.Title,
                Position = exo.Position,
                Sources = exo.Sources.Select(s => new ExerciceSourceModel
                {
                    Type = s.Type,
                    Content = s.Content
                })
            };
        }
    }
}
