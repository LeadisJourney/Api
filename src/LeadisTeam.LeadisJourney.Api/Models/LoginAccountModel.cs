﻿namespace LeadisTeam.LeadisJourney.Api.Models
{
    public class LoginAccountModel {
        public string Email { get; set; }
        public string Password { get; set; }
        public class Response {
            public string Token { get; set; }
            public int Id { get; set; }
        }
    }
}
