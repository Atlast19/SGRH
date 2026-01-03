
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGRH.Domein.Base;
using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Servicios;
using SGRH.Domein.Models.Servicios;
using SGRH.Percistence.Context;

namespace SGRH.Percistence.Repository.Servicios
{
    public class ServicioRepository : IServicioRepository
    {
        private readonly SGHRContext _context;
        private readonly ILogger<ServicioRepository> _logger;
        DbSet<Servicio> _dbSet;
        public ServicioRepository(SGHRContext context, ILogger<ServicioRepository> logger)
        {
            _context = context;
            _logger = logger;
            _dbSet = context.Set<Servicio>();
        }
        public async Task<OperationResult<ServicioModel>> CreateAsync(ServicioModel modelo)
        {
            OperationResult<ServicioModel> result = new OperationResult<ServicioModel>();

            _logger.LogInformation("Proceso para crear un servicio");
            try
            {
                var servicio = new Servicio
                {
                    Nombre = modelo.Nombre,
                    Descripcion = modelo.Descripcion,
                    UsuarioCreacion = modelo.UsuarioCreacion,
                    FechaCreacion = DateTime.Now,
                    Estado = true
                };

                _dbSet.AddAsync(servicio);
                await _context.SaveChangesAsync();

                var servicioModel = new ServicioModel
                {
                    
                    Nombre = modelo.Nombre,
                    Descripcion = modelo.Descripcion,
                    UsuarioCreacion = modelo.UsuarioCreacion,
                    FechaCreacion = DateTime.Now,
                    Estado = true
                };

                result = OperationResult<ServicioModel>.Succes("Servicio creado correctamente", servicioModel);
                _logger.LogInformation("Datos agregados correctamente");
            }
            catch (Exception e) 
            {
                result = OperationResult<ServicioModel>.Failure("Error ingresando los datos" + e.Message);
                _logger.LogError("Error ingresando los datos" + e.Message);
            }
            return result;
        }

        public async Task<OperationResult<ServicioModel>> DeleteAsync(int Id, int IdUsuario)
        {
            OperationResult<ServicioModel> result = new OperationResult<ServicioModel>();

            _logger.LogInformation("Proceso para eliminar un servicio");

            try
            {
                var servicio = await _dbSet.FirstOrDefaultAsync(c => c.IdServicio == Id || c.UsuarioActualizacion == IdUsuario);

                if (servicio == null)
                    return result = OperationResult<ServicioModel>.Failure("No se encontralos los datos a eliminar");

                servicio.UsuarioEliminacion = IdUsuario;
                servicio.Borrado = true;
                servicio.Estado = false;
                servicio.FechaEliminado = DateTime.Now;

                _dbSet.Update(servicio);
                await _context.SaveChangesAsync();

                result = OperationResult<ServicioModel>.Succes("Datos eliminados correctamente");
                _logger.LogInformation("Datos eliminados correctamente");
            }
            catch (Exception e) 
            {
                result = OperationResult<ServicioModel>.Failure("Error eliminando los datos" + e.Message);
                _logger.LogError("Error eliminando los datos" + e.Message);
            }
            return result;
        }

        public async Task<OperationResult<IEnumerable<ServicioModel>>> GetAllAsync()
        {
            OperationResult<IEnumerable<ServicioModel>> result = new OperationResult<IEnumerable<ServicioModel>>();
            _logger.LogInformation("Proceso para cargar todos los servicios");

            try
            {
                var servicio = await _dbSet.ToListAsync();

                var servicios = servicio.Select(c => new ServicioModel
                {
                    IdServicio = c.IdServicio,
                    Nombre = c.Nombre,
                    Descripcion = c.Descripcion,
                    Estado = c.Estado,
                    UsuarioCreacion = c.UsuarioCreacion,
                    FechaCreacion = c.FechaCreacion,
                    FechaEliminado = c.FechaEliminado,
                    UsuarioEliminacion = c.UsuarioEliminacion,
                    Borrado = c.Borrado,
                    FechaActualizacion = c.FechaActualizacion,
                    UsuarioActualizacion = c.UsuarioActualizacion
                });

                if (servicios == null)
                    return result = OperationResult<IEnumerable<ServicioModel>>.Failure("Error cargando los datos");

                result = OperationResult<IEnumerable<ServicioModel>>.Succes("Datos cargados correctamente", servicios);
                _logger.LogInformation("Datos cargados correctamente");
            }
            catch (Exception e)
            {
                result = OperationResult<IEnumerable<ServicioModel>>.Failure("Error cargando todos los servicios" + e.Message);
                _logger.LogError("Error cargand olos datos" + e.Message);
            }
            return result;
        }

        public async Task<OperationResult<ServicioModel>> GetByIdAsync(int Id)
        {
            OperationResult<ServicioModel> result = new OperationResult<ServicioModel>();

            _logger.LogInformation("Proceso de cargar el servicio por ID");

            try
            {
                var servicio = await _dbSet.Where(c => c.IdServicio == Id).Select(c => new ServicioModel
                {
                    IdServicio = c.IdServicio,
                    Nombre = c.Nombre,
                    Descripcion = c.Descripcion,
                    Estado = c.Estado,
                    UsuarioCreacion = c.UsuarioCreacion,
                    FechaCreacion = c.FechaCreacion,
                    FechaEliminado = c.FechaEliminado,
                    UsuarioEliminacion = c.UsuarioEliminacion,
                    Borrado = c.Borrado,
                    FechaActualizacion = c.FechaActualizacion,
                    UsuarioActualizacion = c.UsuarioActualizacion
                }).FirstOrDefaultAsync();

                if (servicio == null)
                    return result = OperationResult<ServicioModel>.Failure("Nose encontraron los datos");

                result = OperationResult<ServicioModel>.Succes("Datos cargados correctamente", servicio);
                _logger.LogInformation("Proceso de cargar el servicio por ID completado");
            }
            catch (Exception e) 
            {
                result = OperationResult<ServicioModel>.Failure("Errpr cargando los datos por ID");
                _logger.LogError("Error cargand olos datos por ID");
            }
            return result;
        }

        public async Task<OperationResult<ServicioModel>> UpdateAsync(ServicioModel modelo)
        {
            OperationResult<ServicioModel> result = new OperationResult<ServicioModel>();

            _logger.LogInformation("Proceso para actualizar el servicio");

            try
            {
                if (modelo == null || modelo.IdServicio == null || modelo.UsuarioActualizacion == null)
                    return result = OperationResult<ServicioModel>.Failure("No se pueden actualizar los datos");

                var servicio = await _dbSet.FirstOrDefaultAsync(c => c.IdServicio == modelo.IdServicio || c.UsuarioActualizacion == modelo.UsuarioActualizacion);

                servicio.IdServicio = modelo.IdServicio;
                servicio.Nombre = modelo.Nombre;
                servicio.Descripcion = modelo.Descripcion;

                servicio.FechaActualizacion = DateTime.Now;
                servicio.UsuarioActualizacion = modelo.UsuarioActualizacion;

                _dbSet.Update(servicio);
                await _context.SaveChangesAsync();

                result = OperationResult<ServicioModel>.Succes("Datos actualizados correctamente");
                _logger.LogInformation("Datos actualizados correctamente");
            }
            catch (Exception e) 
            {
                result = OperationResult<ServicioModel>.Failure("Error actualizando los datos" + e.Message);
                _logger.LogError("Error actualizando los datos" + e.Message);
            }
            return result;
        }
    }
}
