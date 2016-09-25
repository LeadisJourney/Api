using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeadisTeam.LeadisJourney.Core.Entities;

namespace LeadisTeam.LeadisJourney.Services.Contracts
{
    public interface IExerciceService
    {
        void Create(string title, int position, IEnumerable<ExerciceSource> sources);
        Exercice[] GetAll();
        Exercice GetById(int id);
    }
}
