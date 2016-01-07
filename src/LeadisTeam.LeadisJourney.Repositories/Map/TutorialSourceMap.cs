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
            Table("tutorialSources");
        }
    }
}