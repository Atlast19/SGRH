using SGRH.Api.Middleware;
using SGRH.Application.Interfaces.habitacion;
using SGRH.Application.Interfaces.Services;
using SGRH.Application.Interfaces.Usuarios;
using SGRH.Application.Services.habitacion;
using SGRH.Application.Services.Servicios;
using SGRH.Application.Services.Usuarios;
using SGRH.Domein.Interfaces.Habitaciones;
using SGRH.Domein.Interfaces.Servicios;
using SGRH.Domein.Interfaces.Usuarios;
using SGRH.Percistence.Repository.Habitaciones;
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

            #region "Schema: Habitacion"
            service.AddScoped<ICategoriumService, CategoriumService>();
            service.AddScoped<ICategoriumRepository, CategoriumRepository>();

            service.AddScoped<IEstadoHabitacionService, EstadoHabitacionService>();
            service.AddScoped<IEstadoHabitacionRepository, EstadoHabitacionRepository>();

            service.AddScoped<IHabitacionService, HabitacionService>();
            service.AddScoped<IHabitacionRepository, HabitacionRepository>();

            service.AddScoped<IPisoService, PisoService>();
            service.AddScoped<IPisoRepository, PisoRepository>();

            service.AddScoped<ITarifaService, TarifaService>();
            service.AddScoped<ITarifaRepository, TarifaRepository>();
            #endregion


            service.AddTransient<GlobalExecptionMiddleware>();



        }
    }
}
