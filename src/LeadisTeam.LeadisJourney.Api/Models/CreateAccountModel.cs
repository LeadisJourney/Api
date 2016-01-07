namespace LeadisTeam.LeadisJourney.Api.Models {
	public class CreateAccountModel {
		public string Email { get; set; }
		public string Pseudo { get; set; }
		public string Password { get; set; }

		//User infos
		public string Name { get; set; }
		public string FirstName { get; set; }
	}
}
