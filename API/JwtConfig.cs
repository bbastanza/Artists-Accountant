using System.Text;
using Core.Services.DbServices;
using Core.Services.JwtAuthentication;
using Core.Services.UserServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace API
{
    public static class JwtConfig
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            var key = configuration["JwtKey"];
            
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddSingleton<IGenerateJwtToken>(
                new GenerateJwtToken(key, new GetUserData(new SqlServer(configuration))));
        }
    }
}