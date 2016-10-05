using FluentNHibernate.Mapping;
using LeadisTeam.LeadisJourney.Core.Entities;

namespace LeadisTeam.LeadisJourney.Repositories.Map
{
    public class ExerciceSourceMap : ClassMap<ExerciceSource> {
        public ExerciceSourceMap() {
            Id(source => source.Id).GeneratedBy.Increment();
            Map(c => c.Content);
            Map(c => c.Type);
            References(x => x.Exercice)
             .Column("ExerciceId")
             .Cascade.All();
            Table("exerciceSources");
        }
    }
}
