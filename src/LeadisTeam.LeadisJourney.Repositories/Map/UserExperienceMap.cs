using FluentNHibernate.Mapping;
using LeadisTeam.LeadisJourney.Core.Entities;

namespace LeadisTeam.LeadisJourney.Repositories.Map
{
    public class UserExperienceMap : ClassMap<UserExperience> {
        public UserExperienceMap() {
            Id(userExperience => userExperience.Id).GeneratedBy.Increment();
            Map(c => c.Code);
//missing arguments
            Table("userExperiences");
        }
    }
}
