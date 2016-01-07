using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LeadisTeam.LeadisJourney.Core.Entities;

namespace LeadisTeam.LeadisJourney.Repositories.Map
{
    public class UserExperienceMap : ClassMap<UserExperience> {
        public UserExperienceMap() {
            Id(userExperience => userExperience.Id).GeneratedBy.Increment();
            Map(c => c.Code);
            Map(c => c.CreationDate);
            References(c => c.Creator);
            Table("userExperiences");
        }
    }
}
