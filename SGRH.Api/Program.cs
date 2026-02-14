using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using SGRH.Api.Dependencies;
using SGRH.Api.Middleware;

using SGRH.Application.Validations.Usuarios.UsuarioValidator;
using SGRH.Percistence.Context;

namespace SGRH.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<SGHRContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConectionString")));

            builder.Services.RegisterOfRependencies();

            builder.Services.AddControllers();

            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblyContaining<CreateUsuarioValidation>();
            builder.Services.AddValidatorsFromAssemblyContaining<UpdateUsuarioValidation>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseMiddleware<GlobalExecptionMiddleware>();

            app.MapControllers();

             app.Run();
        }
    }
}
