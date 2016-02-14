using System;
using System.IdentityModel.Tokens;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNet.Authentication.JwtBearer;

namespace LeadisTeam.LeadisJourney.Api.Security {
    public static class JwtExtension {
        public static void AddJwtAuthentication(this IServiceCollection serviceCollection,
            string rsaKeyPath,
            string fileName,
            string audience,
            string issuer) {
            var rsaSecurityKey = RsaHelper.GetRsaSecurityKey(rsaKeyPath, fileName);
            serviceCollection.AddInstance(new TokenAuthOption {
                Audience = audience,
                Issuer = issuer,
                SigningCredentials = new SigningCredentials(rsaSecurityKey, SecurityAlgorithms.RsaSha256Signature),
                Key = rsaSecurityKey
            });
            serviceCollection.AddAuthorization(auth => {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });
        }

        public static void UseJwtAuthentication(this IApplicationBuilder applicationBuilder,
            string rsaKeyPath,
            string fileName,
            string audience,
            string issuer) {
            var rsaSecurityKey = RsaHelper.GetRsaSecurityKey(rsaKeyPath, fileName);
            applicationBuilder.UseJwtBearerAuthentication(options => {
                // Basic settings - signing key to validate with, audience and issuer.
                options.TokenValidationParameters.IssuerSigningKey = rsaSecurityKey;
                options.TokenValidationParameters.ValidAudience = audience;
                options.TokenValidationParameters.ValidIssuer = issuer;

                // When receiving a token, check that we've signed it.
                options.TokenValidationParameters.ValidateSignature = true;

                // When receiving a token, check that it is still valid.
                options.TokenValidationParameters.ValidateLifetime = true;

                // This defines the maximum allowable clock skew - i.e. provides a tolerance on the 
                // token expiry time when validating the lifetime. As we're creating the tokens locally
                // and validating them on the same machines which should have synchronised 
                // time, this can be set to zero. Where external tokens are used, some leeway here 
                // could be useful.
                options.TokenValidationParameters.ClockSkew = TimeSpan.Zero;
            });
        }
    }
}
