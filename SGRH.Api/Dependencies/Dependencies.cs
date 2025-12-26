using Microsoft.EntityFrameworkCore;
using SGRH.Application.Interfaces.Usuarios;
using SGRH.Application.Services.Usuarios;
using SGRH.Domein.Interfaces.Usuarios;
using SGRH.Percistence.Context;
using SGRH.Percistence.Repository.Usuario;


namespace SGRH.Api.Dependencies
{
    public static class Dependencies
    {
        public static void RegisterOfRependencies(this IServiceCollection service) 
        {
            

            service.AddScoped<IClienteRepository, ClienteRepository>();
            service.AddScoped<IClienteService, ClienteService>();

        }
    }
}
