using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LeadisTeam.LeadisJourney.Core.Entities;

namespace LeadisTeam.LeadisJourney.Repositories.Map
{
    public class ExerciceMap : ClassMap<Exercice> {

        public ExerciceMap() {
            Id(exercice => exercice.Id).GeneratedBy.Increment();
            HasOne(c => c.Source);
            HasMany(c => c.Helps);
            Map(c => c.Position);
            Map(c => c.Title);
            HasMany(c => c.Tutorials);
            Table("exercices");
        }
    }
}
