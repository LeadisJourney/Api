using FluentNHibernate.Mapping;
using LeadisTeam.LeadisJourney.Core.Entities;

namespace LeadisTeam.LeadisJourney.Repositories.Map
{
    public class UserMap : ClassMap<User> {
        public UserMap() {
            Id(user => user.Id).GeneratedBy.Increment();
            Map(c => c.FirstName);
            Map(c => c.Name);
	        References(c => c.Account).Cascade.All().PropertyRef("User");
			Table("users");
        }
    }
}
