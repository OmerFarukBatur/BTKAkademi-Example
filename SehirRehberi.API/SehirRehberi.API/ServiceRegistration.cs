using SehirRehberi.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SehirRehberi.API
{
    static public class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            ConfigurationManager configurationManager = new();
            var key = Encoding.ASCII.GetBytes(configurationManager.GetSection("AppSettings:Token").Value);

            services.AddDbContext<DataContext>(options => options.UseNpgsql(Configuration.ConfigurationString));
            services.AddScoped<IAppRepository, AppRepositoriy>();
             services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling =
                   Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });
        }
    }
}
