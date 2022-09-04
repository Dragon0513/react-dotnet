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

            Services.AddDbContext<DataContext>(x => x.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

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
