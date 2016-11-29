using FluentNHibernate.Mapping;
using LeadisTeam.LeadisJourney.Core.Entities;

namespace LeadisTeam.LeadisJourney.Repositories.Map
{
    public class ExerciceMap : ClassMap<Exercice> {

        public ExerciceMap() {
            Id(exercice => exercice.Id).GeneratedBy.Increment();
            Map(c => c.EntityState).CustomType<int>();
            HasMany(c => c.Sources)
                .KeyColumn("ExerciceId");
            HasMany(c => c.Helps);
            Map(c => c.Position);
            Map(c => c.Title);
            HasMany(c => c.Tutorials);
            Table("exercices");
        }
    }
}
