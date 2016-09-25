using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeadisTeam.LeadisJourney.Core.Entities;
using LeadisTeam.LeadisJourney.Core.Repositories;
using LeadisTeam.LeadisJourney.Services.Contracts;
using LeadisTeam.LeadisJourney.Services.Exceptions;

namespace LeadisTeam.LeadisJourney.Services
{
    public class ExerciceService : IExerciceService
    {
        private readonly ITutorialRepository _tutorialRepository;
        private readonly IExerciceRepository _exerciceRepository;
        public ExerciceService(IExerciceRepository exerciceRepository, ITutorialRepository tutorialRepository)
        {
            _tutorialRepository = tutorialRepository;
            _exerciceRepository = exerciceRepository;
        }
        public void Create(string title, int position, IEnumerable<ExerciceSource> sources)
        {
            if (_exerciceRepository.All().Any(s => s.Title.Equals(title)))
                throw new ExistingTitleException();
            Exercice exo = new Exercice()
            {
                Title = title,
                Position = position
            };
            _exerciceRepository.Save(exo);
        }

        public Exercice[] GetAll()
        {
            return _exerciceRepository.GetAllWithSources().ToArray();
        }

        public Exercice GetById(int id)
        {
            return _exerciceRepository.GetWithSource(id);
        }
    }
}
