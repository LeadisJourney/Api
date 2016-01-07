using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LeadisTeam.LeadisJourney.Core.Entities;

namespace LeadisTeam.LeadisJourney.Repositories.Map
{
    public class ExerciceSourceMap : ClassMap<ExerciceSource> {
        public ExerciceSourceMap() {
            Id(source => source.Id).GeneratedBy.Increment();
            Map(c => c.Content);
            Map(c => c.Type);
            Table("exerciceSources");
        }
    }
}
