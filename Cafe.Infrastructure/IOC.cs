using Cafe.Domain.Features.User;
using Cafe.Infrastructure.Common.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;
using Cafe.Contracts.Core;
using Cafe.Infrastructure.Common;

namespace Cafe.Infrastructure
{
    public static class IOC
    {
        public static void RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.Configure<JWTSettings>(configuration.GetSection(JWTSettings.SectionName));

            services.AddScoped<IJWTGenerator, JWTGenerator>();

            services.AddDbContext<RawaanDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );
            services.AddScoped<IDataBaseSeeder, DataBaseSeeder>();

            services.SetUpIdentity();
        }

        private static void SetUpIdentity(this IServiceCollection services)
        {
            services.AddScoped(sp =>
            {
                var options = sp.GetRequiredService<IOptions<JWTSettings>>().Value;
                return options;
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireUppercase = false;
            });

            services.AddIdentity<RawaanUser, IdentityRole>()
                .AddEntityFrameworkStores<RawaanDBContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                var jwtSettings = services.BuildServiceProvider().GetService<JWTSettings>();

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = jwtSettings?.Audience ?? "",
                    ValidIssuer = jwtSettings?.Issuer ?? "",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(
                        jwtSettings?.Secret ?? ""
                    ))
                };
            });
        }
    }
}
