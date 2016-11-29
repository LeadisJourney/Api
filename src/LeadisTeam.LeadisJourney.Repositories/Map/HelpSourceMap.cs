using FluentNHibernate.Mapping;
using LeadisTeam.LeadisJourney.Core.Entities;

namespace LeadisTeam.LeadisJourney.Repositories.Map {
    public class HelpSourceMap : ClassMap<HelpSource>
    {
        public HelpSourceMap()
        {
            Id(source => source.Id).GeneratedBy.Increment();
            Map(c => c.Content);
            Map(c => c.Type);
            Map(c => c.EntityState).CustomType<int>();
            Table("helpSources");
        }
    }
}