using Application.Activities;
using Application.Core;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection Services,
            IConfiguration config)
        {
            Services.AddControllers().AddFluentValidation(config => {
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
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
                });
            });

            Services.AddMediatR(typeof(List.Handler).Assembly);
            Services.AddAutoMapper(typeof(MappinngProfiles).Assembly);

            return Services;
        }
    }
}
