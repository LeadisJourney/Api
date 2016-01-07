using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LeadisTeam.LeadisJourney.Core.Entities;

namespace LeadisTeam.LeadisJourney.Repositories.Map
{
    public class TutorialMap : ClassMap<Tutorial> {
        public TutorialMap() {
            Id(tutorial => tutorial.Id).GeneratedBy.Increment();
            References(c => c.Exercice);
            HasOne(c => c.Source);
            Map(c => c.Title);
            Table("tutorials");
        }
    }
}
