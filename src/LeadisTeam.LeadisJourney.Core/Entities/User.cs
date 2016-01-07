namespace LeadisTeam.LeadisJourney.Core.Entities
{
    public class User : IEntity
    {
        //Only USER infos, all the other informations are in Account
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string FirstName { get; set; }
        public virtual Account Account { get; set; }
    }
}