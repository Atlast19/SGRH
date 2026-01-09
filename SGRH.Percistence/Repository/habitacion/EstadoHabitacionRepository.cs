
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGRH.Domein.Base;
using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Habitaciones;
using SGRH.Domein.Models.Habitaciones;
using SGRH.Percistence.Context;

namespace SGRH.Percistence.Repository.Habitaciones
{
    public class EstadoHabitacionRepository : IEstadoHabitacionRepository
    {
        private readonly SGHRContext _context;
        private readonly ILogger<EstadoHabitacionRepository> _logger;
        DbSet<EstadoHabitacion> _dbSet;
        public EstadoHabitacionRepository(SGHRContext context, ILogger<EstadoHabitacionRepository> logger)
        {
            _context = context;
            _logger = logger;
            _dbSet = context.Set<EstadoHabitacion>();
        } 
        public async Task<OperationResult<EstadoHabitacionModel>> CreateAsync(EstadoHabitacionModel modelo)
        {
            OperationResult<EstadoHabitacionModel> result = new OperationResult<EstadoHabitacionModel>();
            _logger.LogInformation("Proceso para crear el estadod de una habitacion");

            try
            {
                var estadohabitacion = new EstadoHabitacion
                {
                    IdEstadoHabitacion = modelo.IdEstadoHabitacion,
                    Descripcion = modelo.Descripcion,
                    Estado = true,
                    UsuarioCreacion = modelo.UsuarioCreacion,
                    FechaCreacion = DateTime.Now
                };

                _dbSet.AddAsync(estadohabitacion);
                await _context.SaveChangesAsync();

                var estadohabitacionModel = new EstadoHabitacionModel
                {
                    IdEstadoHabitacion = modelo.IdEstadoHabitacion,
                    Descripcion = modelo.Descripcion,
                    Estado = true,
                    UsuarioCreacion = modelo.UsuarioCreacion,
                    FechaCreacion = DateTime.Now
                };

                result = OperationResult<EstadoHabitacionModel>.Succes("Datos agregados correctamente", estadohabitacionModel);
                _logger.LogInformation("Datos cargados correctamente");
            }
            catch (Exception e) 
            {
                result = OperationResult<EstadoHabitacionModel>.Failure("Error cargando los datos" + e.Message);
                _logger.LogError("Error cargando los datos" + e.Message);
            }
            return result;
        }

        public async Task<OperationResult<EstadoHabitacionModel>> DeleteAsync(int Id, int IdUsuario)
        {
            OperationResult<EstadoHabitacionModel> result = new OperationResult<EstadoHabitacionModel>();
            _logger.LogInformation("Proceso para eliminar el estado de una habitacion");

            try
            {
                var estadohabitacion = await _dbSet.FirstOrDefaultAsync(c => c.IdEstadoHabitacion == Id || c.UsuarioEliminacion == IdUsuario);

                if (estadohabitacion == null)
                    return result = OperationResult<EstadoHabitacionModel>.Failure("No se encontraron los datos a eliminar");

                estadohabitacion.Borrado = true;
                estadohabitacion.FechaEliminado = DateTime.Now;
                estadohabitacion.UsuarioEliminacion = IdUsuario;
                estadohabitacion.Estado = false;

                _dbSet.Update(estadohabitacion);
                await _context.SaveChangesAsync();

                result = OperationResult<EstadoHabitacionModel>.Succes("Datos eliminados correctamente");
                _logger.LogInformation("Datos eliminados correctamente");
            }
            catch (Exception e) 
            {
                result = OperationResult<EstadoHabitacionModel>.Failure("Error eliminando los datos" + e.Message);
                _logger.LogError("Error eliminando los datos" + e.Message);
            }
            return result;
        }

        public async Task<OperationResult<IEnumerable<EstadoHabitacionModel>>> GetAllAsync()
        {
            OperationResult<IEnumerable<EstadoHabitacionModel>> result = new OperationResult<IEnumerable<EstadoHabitacionModel>>();
            _logger.LogInformation("Proceso para cargar todos los estados de las habitaciones");

            try
            {
                var estadohabitacion = await _dbSet.ToListAsync();

                var estadohabitacionModel = estadohabitacion.Select(c => new EstadoHabitacionModel
                {
                    IdEstadoHabitacion = c.IdEstadoHabitacion,
                    Descripcion = c.Descripcion,
                    Estado = c.Estado,
                    UsuarioCreacion = c.UsuarioCreacion,
                    FechaCreacion = c.FechaCreacion,
                    UsuarioActualizacion = c.UsuarioActualizacion,
                    FechaActualizacion = c.FechaActualizacion,
                    UsuarioEliminacion = c.UsuarioEliminacion,
                    FechaEliminado = c.FechaEliminado,
                    Borrado = c.Borrado
                });

                if (estadohabitacionModel == null)
                    return result = OperationResult<IEnumerable<EstadoHabitacionModel>>.Failure("No se encontraron datos");

                result = OperationResult<IEnumerable<EstadoHabitacionModel>>.Succes("Datos cargados correctmaente", estadohabitacionModel);
                _logger.LogInformation("Datos cargados correctamente");
            }
            catch (Exception e) 
            {
                result = OperationResult<IEnumerable<EstadoHabitacionModel>>.Failure("Error cargando los datos" +e.Message);
                _logger.LogError("Error cargando los datos" + e.Message);
            }
            return result;
        }

        public async Task<OperationResult<EstadoHabitacionModel>> GetByIdAsync(int Id)
        {
            OperationResult<EstadoHabitacionModel> result = new OperationResult<EstadoHabitacionModel>();
            _logger.LogInformation("Proceso para cargar los datos por ID");

            try
            {
                var estadohabitacion = await _dbSet.Where(c => c.IdEstadoHabitacion == Id).Select(c => new EstadoHabitacionModel 
                {
                    IdEstadoHabitacion = c.IdEstadoHabitacion,
                    Descripcion = c.Descripcion,
                    Estado = c.Estado,
                    UsuarioCreacion = c.UsuarioCreacion,
                    FechaCreacion = c.FechaCreacion,
                    UsuarioActualizacion = c.UsuarioActualizacion,
                    FechaActualizacion = c.FechaActualizacion,
                    UsuarioEliminacion = c.UsuarioEliminacion,
                    FechaEliminado = c.FechaEliminado,
                    Borrado = c.Borrado
                }).FirstOrDefaultAsync();

                if (estadohabitacion == null)
                    return result = OperationResult<EstadoHabitacionModel>.Failure("No se encontraron los datos");

                result = OperationResult<EstadoHabitacionModel>.Succes("Datos cargados correctamente");
                _logger.LogInformation("Datos cargados correctamente");
            }
            catch (Exception e) 
            {
                result = OperationResult<EstadoHabitacionModel>.Failure("Error cargando losdatos por ID" + e.Message);
                _logger.LogError("Error cargando los datos por ID" + e.Message);
            }
            return result;
        }

        public async Task<OperationResult<EstadoHabitacionModel>> UpdateAsync(EstadoHabitacionModel modelo)
        {
            OperationResult<EstadoHabitacionModel> result = new OperationResult<EstadoHabitacionModel>();
            _logger.LogInformation("Proceso para actualizar el estado de la habitacion");

            try
            {
                if (modelo == null || modelo.IdEstadoHabitacion == null || modelo.UsuarioActualizacion == null)
                    return result = OperationResult<EstadoHabitacionModel>.Failure("No se encontraron los datos a actualizar");

                var estadohabitacion = await _dbSet.FirstOrDefaultAsync(c => c.IdEstadoHabitacion == modelo.IdEstadoHabitacion || c.UsuarioActualizacion == modelo.UsuarioActualizacion);

                estadohabitacion.Descripcion = modelo.Descripcion;
                estadohabitacion.UsuarioActualizacion = modelo.UsuarioActualizacion;
                estadohabitacion.FechaActualizacion = DateTime.Now;

                _dbSet.Update(estadohabitacion);
                await _context.SaveChangesAsync();

                result = OperationResult<EstadoHabitacionModel>.Succes("Datos actualizados correctamente");
                _logger.LogInformation("Datos actualizados correctamente");
            }
            catch (Exception e) 
            {
                result = OperationResult<EstadoHabitacionModel>.Failure("Error actualizando los datos" + e.Message);
                _logger.LogError("Error actualizando los datos" + e.Message);
            }
            return result;
        }
    }
}
