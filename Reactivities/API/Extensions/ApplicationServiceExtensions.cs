using Application.Activities;
using Application.Core;
using Application.Interfaces;
using FluentValidation.AspNetCore;
using Infrastructure.Photos;
using Infrastructure.Security;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection Services,
            IConfiguration config)
        {
            Services.AddControllers(opt =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                opt.Filters.Add(new AuthorizeFilter(policy));
            }).AddFluentValidation(config => {
                config.RegisterValidatorsFromAssemblyContaining<Create>();
            });

            Services.AddDbContext<DataContext>
                (x => x.UseNpgsql(config.GetConnectionString("DefaultConnection")));


            //Learn more about configuring Swagger / OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            //Services.AddDbContext<DataContext>(options =>
            //{
            //    var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            //    string connStr;

            //    // Depending on if in development or production, use either Heroku-provided
            //    // connection string, or development connection string from env var.
            //    if (env == "Development")
            //    {
            //        // Use connection string from file.
            //        connStr = config.GetConnectionString("DefaultConnection");
            //    }
            //    else
            //    {
            //        // Use connection string provided at runtime by Heroku.
            //        var connUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

            //        // Parse connection URL to connection string for Npgsql
            //        connUrl = connUrl.Replace("postgres://", string.Empty);
            //        var pgUserPass = connUrl.Split("@")[0];
            //        var pgHostPortDb = connUrl.Split("@")[1];
            //        var pgHostPort = pgHostPortDb.Split("/")[0];
            //        var pgDb = pgHostPortDb.Split("/")[1];
            //        var pgUser = pgUserPass.Split(":")[0];
            //        var pgPass = pgUserPass.Split(":")[1];
            //        var pgHost = pgHostPort.Split(":")[0];
            //        var pgPort = pgHostPort.Split(":")[1];

            //        connStr = $"Server={pgHost};Port={pgPort};User Id={pgUser};Password={pgPass};Database={pgDb}; SSL Mode=Require; Trust Server Certificate=true";
            //    }

            //    // Whether the connection string came from the local development configuration file
            //    // or from the environment variable from Heroku, use it to set up your DbContext.
            //    options.UseNpgsql(connStr);
            //});

            Services.AddEndpointsApiExplorer();
            Services.AddSwaggerGen();

            Services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:3000");
                });
            });

            Services.AddMediatR(typeof(List.Handler).Assembly);
            Services.AddAutoMapper(typeof(MappinngProfiles).Assembly);
            Services.AddScoped<IUserAccessor, UserAccessor>();
            Services.AddScoped<IPhotoAccessor, PhotoAccessor>();

            Services.Configure<CloudinarySettings>(config.GetSection("Cloudinary"));

            Services.AddSignalR();

            return Services;
        }
    }
}
