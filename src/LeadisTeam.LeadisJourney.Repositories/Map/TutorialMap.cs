using FluentNHibernate.Mapping;
using LeadisTeam.LeadisJourney.Core.Entities;

namespace LeadisTeam.LeadisJourney.Repositories.Map
{
    public class TutorialMap : ClassMap<Tutorial> {
        public TutorialMap() {
            Id(tutorial => tutorial.Id).GeneratedBy.Increment();
            References(c => c.Exercice);
            HasMany(c => c.Sources)
                .KeyColumn("TutorialId");
            Map(c => c.Title);
            Table("tutorials");
        }
    }
}
