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
        private readonly ISourceRepository _sourceRepository;
        private readonly IExerciceRepository _exerciceRepository;
        public ExerciceService(IExerciceRepository exerciceRepository, ISourceRepository sourceRepository)
        {
            _sourceRepository = sourceRepository;
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
            foreach (var exerciceSource in sources)
            {
                exerciceSource.ExerciceId = exo.Id;
                exerciceSource.Exercice = exo;
                _sourceRepository.Save(exerciceSource);
            }
        }

        public Exercice[] GetAll()
        {
            return _exerciceRepository.GetAllWithSources().ToArray();
        }

        public Exercice GetById(int id)
        {
            return _exerciceRepository.GetWithSource(id);
        }

        public void Update(int id, string title, int position, IEnumerable<ExerciceSource> sources)
        {
            var exo = _exerciceRepository.FindBy(id);
            if (exo == null)
            {
                throw new BadIdException();
            }
            exo.Title = title;
            exo.Position = position;
            _exerciceRepository.Save(exo);
            exo.Sources.Clear();
            foreach (var exerciceSource in sources)
            {
                exo.Sources.Add(exerciceSource);
                exerciceSource.ExerciceId = exo.Id;
                exerciceSource.Exercice = exo;
                _sourceRepository.Save(exerciceSource);
            }
        }

        public void Desactivate(int id)
        {
            var exo = _exerciceRepository.FindBy(id);
            _sourceRepository.Delete(exo.Sources);
            exo.Sources.Clear();
            _exerciceRepository.Delete(exo);
        }
    }
}
