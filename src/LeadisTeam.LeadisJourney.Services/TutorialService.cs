using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LeadisTeam.LeadisJourney.Core.Entities;
using LeadisTeam.LeadisJourney.Core.Repositories;
using LeadisTeam.LeadisJourney.Services.Contracts;
using LeadisTeam.LeadisJourney.Services.Exceptions;

namespace LeadisTeam.LeadisJourney.Services
{
    public class TutorialService : ITutorialService{
        private readonly ITutorialRepository _tutorialRepository;
        private readonly IExerciceRepository _exerciceRepository;
        private readonly ISourceRepository _sourceRepository;

        public TutorialService(ITutorialRepository tutorialRepository, IExerciceRepository exerciceRepository, ISourceRepository sourceRepository)
        {
            _tutorialRepository = tutorialRepository;
            _exerciceRepository = exerciceRepository;
            _sourceRepository = sourceRepository;
        }

        public Tutorial[] GetAll()
        {
            return _tutorialRepository.GetAllWithSources().ToArray();
        }

        public Tutorial GetById(int id)
        {
            return _tutorialRepository.GetWithSource(id);
        }

        public void Create(string title, IEnumerable<TutorialSource> tutorialSources, int exerciceId)
        {
            if (_tutorialRepository.All().Any(s => s.Title.Equals(title)))
                throw new ExistingTitleException();
            Exercice exo = _exerciceRepository.FindBy(exerciceId);
            if (exo == null)
                throw new ExerciceNotFoundException();
            Tutorial tuto = new Tutorial()
            {
                Title = title,
                Exercice = exo,
                ExerciceId = exerciceId
            };
            _tutorialRepository.Save(tuto);
            foreach (var tutorialSource in tutorialSources)
            {
                tutorialSource.TutorialId = tuto.Id;
                tutorialSource.Tutorial = tuto;
                _sourceRepository.Save(tutorialSource);
            }
        }

        public void Update(int id, string title, int exerciceId, IEnumerable<TutorialSource> tutorialSources)
        {
            var tuto = _tutorialRepository.FindBy(id);
            if (tuto == null)
            {
                throw new BadIdException();
            }
            tuto.Title = title;
            tuto.ExerciceId = exerciceId;
            _tutorialRepository.Save(tuto);
            //TODO delete sources
            foreach (var tutorialSource in tutorialSources)
            {
                tutorialSource.TutorialId = tuto.Id;
                tutorialSource.Tutorial = tuto;
                _sourceRepository.Save(tutorialSource);
            }
        }

        public void Desactivate(int id)
        {
            var tuto = _tutorialRepository.FindBy(id);
            tuto.Sources.Clear();
            //TODO
            // EntityState desactivated
        }
    }
}
