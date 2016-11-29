using FluentNHibernate.Mapping;
using LeadisTeam.LeadisJourney.Core.Entities;

namespace LeadisTeam.LeadisJourney.Repositories.Map {
    public class TutorialSourceMap : ClassMap<TutorialSource>
    {
        public TutorialSourceMap()
        {
            Id(source => source.Id).GeneratedBy.Increment();
            Map(c => c.Content);
            Map(c => c.Type);
            Map(c => c.EntityState).CustomType<int>();
            References(x => x.Tutorial)
                .Column("TutorialId")
                .Cascade.All();
            Table("tutorialSources");
        }
    }
}