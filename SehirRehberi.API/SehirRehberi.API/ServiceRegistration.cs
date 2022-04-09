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
            var key = Encoding.ASCII.GetBytes(Configuration.ConfigurationTokenString);

            services.AddDbContext<DataContext>(options => options.UseNpgsql(Configuration.ConfigurationString));
            services.AddScoped<IAppRepository, AppRepositoriy>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling =
                   Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
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
