using SGRH.Application.Interfaces.Services;
using SGRH.Application.Interfaces.Usuarios;
using SGRH.Application.Services.Servicios;
using SGRH.Application.Services.Usuarios;
using SGRH.Domein.Interfaces.Servicios;
using SGRH.Domein.Interfaces.Usuarios;
using SGRH.Percistence.Repository.Servicios;
using SGRH.Percistence.Repository.Usuario;
using SGRH.Percistence.Repository.Usuarios;


namespace SGRH.Api.Dependencies
{
    public static class Dependencies
    {
        public static void RegisterOfRependencies(this IServiceCollection service) 
        {

            #region "Schema: Ususarios"
            service.AddScoped<IClienteRepository, ClienteRepository>();
            service.AddScoped<IClienteService, ClienteService>();

            service.AddScoped<IUsuarioRepository, UsuarioRepository>();
            service.AddScoped<IUsuarioService, UsuarioService>();

            service.AddScoped<IRolUsuarioRepository, RolUsuarioRepository>();
            service.AddScoped<IRolUsuarioService, RolUsuarioService>();
            #endregion

            #region "Schema: Servicios"
            service.AddScoped<IServicioService, ServicioService>();
            service.AddScoped<IServicioRepository, ServicioRepository>();

            service.AddScoped<IReservaServices, ReservaService>();
            service.AddScoped<IReservaRepository, ReservaRepository>();
            #endregion

        }
    }
}
