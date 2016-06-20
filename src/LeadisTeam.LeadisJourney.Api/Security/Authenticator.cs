﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.IdentityModel.Tokens;

namespace LeadisTeam.LeadisJourney.Api.Security
{
    public class Authenticator
    {
        private readonly TokenAuthOption _tokenAuthOption;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

        public Authenticator(TokenAuthOption tokenAuthOption) {
            _tokenAuthOption = tokenAuthOption;
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }

        public string GetToken(Account user, DateTime? expires) {

            // Here, you should create or look up an identity for the user which is being authenticated.
            // For now, just creating a simple generic identity.
            var identity = new ClaimsIdentity(new GenericIdentity(user, "TokenAuth"),
                new[] { new Claim("UserId", "1", ClaimValueTypes.Integer) });

            var securityToken = _jwtSecurityTokenHandler.CreateToken(new SecurityTokenDescriptor {
                Audience = _tokenAuthOption.Audience,
                Issuer = _tokenAuthOption.Issuer,
                Subject = identity,
                Expires = expires,
                SigningCredentials = _tokenAuthOption.SigningCredentials
            });
            return _jwtSecurityTokenHandler.WriteToken(securityToken);
        }

        public bool IsValidToken(string token) {

            var validationParameters = new TokenValidationParameters {
                ValidateLifetime = true,
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                ValidAudience = _tokenAuthOption.Audience,
                ValidIssuer = _tokenAuthOption.Issuer,
                IssuerSigningKey = _tokenAuthOption.Key
            };

            SecurityToken validatedToken;
            try {
                var principal = _jwtSecurityTokenHandler.ValidateToken(token, validationParameters, out validatedToken);
            }
            catch (Exception) {
                return false;
            }
            return validatedToken != null;
        }
    }
}