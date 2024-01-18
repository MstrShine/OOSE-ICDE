using HAN.OOSE.ICDE.API.JWT;
using HAN.OOSE.ICDE.API.JWT.Utils;
using HAN.OOSE.ICDE.API.Middleware;
using HAN.OOSE.ICDE.API.Swagger;
using HAN.OOSE.ICDE.Logic.Extensions;
using HAN.OOSE.ICDE.Logic.Mapping.Extensions;
using HAN.OOSE.ICDE.Persistency.Database;
using HAN.OOSE.ICDE.Persistency.Database.Extensions;
using HAN.OOSE.ICDE.Persistency.Database.Repository.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;

namespace HAN.OOSE.ICDE.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var config = builder.Configuration;
            // Add services to the container.
            builder.Services.AddCors();

            builder.Services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    var jwtOptions = config.GetSection("JwtOptions").Get<JwtOptions>();
                    var signingKey = Encoding.UTF8.GetBytes(jwtOptions.SigningKey);

                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtOptions.Issuer,
                        ValidAudience = jwtOptions.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(signingKey),
                        ClockSkew = TimeSpan.Zero,
                    };
                });
            builder.Services.AddAuthorization();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            builder.Services.AddTransient<IJwtUtils, JwtUtils>();
            builder.Services.AddDatabase();
            builder.Services.AddRepositories();
            builder.Services.AddMapping();
            builder.Services.AddLogic();


            var app = builder.Build();
            app.EnsureMigrationOfContext<DataContext>();

            app.UseCors(o => o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseMiddleware<HttpRequestLoggerMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}