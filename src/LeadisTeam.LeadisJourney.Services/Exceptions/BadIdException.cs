namespace LeadisTeam.LeadisJourney.Services.Exceptions
{
    public class BadIdException : BusinessException
    {
        public BadIdException() : base("This ID does not exist")
        {
        }
    }
}