using FluentNHibernate.Mapping;
using LeadisTeam.LeadisJourney.Core.Entities;

namespace LeadisTeam.LeadisJourney.Repositories.Map {
    public class AccountMap : ClassMap<Account> {
        public AccountMap() {
	        Id(account => account.Id).GeneratedBy.Increment();
            Map(c => c.Pseudo);
            Map(c => c.Email);
            Map(c => c.IsOwner);
            Map(c => c.Password);
            Map(c => c.EntityState).CustomType<int>();
            HasMany(c => c.UserExperience);
            HasManyToMany(c => c.Group);
	        References(c => c.User).Unique().Cascade.All();
            Table("accounts");
        }
    }
}