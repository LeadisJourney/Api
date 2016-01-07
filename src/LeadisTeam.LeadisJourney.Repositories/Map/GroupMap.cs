using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LeadisTeam.LeadisJourney.Core.Entities;

namespace LeadisTeam.LeadisJourney.Repositories.Map
{
    public class GroupMap : ClassMap<Group> {
        public GroupMap() {
            Id(group => group.Id).GeneratedBy.Increment();
            HasManyToMany(c => c.Admins);
            HasManyToMany(c => c.Members);
            Map(c => c.Name);
            Table("groups");
        }
    }
}
