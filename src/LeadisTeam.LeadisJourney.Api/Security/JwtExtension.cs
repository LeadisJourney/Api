using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;

namespace LeadisTeam.LeadisJourney.Api.Security {
    public static class JwtExtension {
        public static void AddJwtAuthentication(this IServiceCollection serviceCollection,
            string rsaKeyPath,
            string fileName,
            string audience,
            string issuer) {
            var rsaSecurityKey = RsaHelper.GetRsaSecurityKey(rsaKeyPath, fileName);
            serviceCollection.AddSingleton(new TokenAuthOption {
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

            applicationBuilder.UseJwtBearerAuthentication(new JwtBearerOptions {
                TokenValidationParameters = {
                    IssuerSigningKey = rsaSecurityKey,
                    ValidAudience = audience,
                    ValidIssuer = issuer,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                }
            });
        }
    }
}
