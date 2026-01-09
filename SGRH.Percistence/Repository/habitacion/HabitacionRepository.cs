
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGRH.Domein.Base;
using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Habitaciones;
using SGRH.Domein.Models.Habitaciones;
using SGRH.Percistence.Context;


namespace SGRH.Percistence.Repository.Habitaciones
{
    public class HabitacionRepository : IHabitacionRepository
    {
        private readonly SGHRContext _context;
        private readonly ILogger<HabitacionRepository> _logger;
        DbSet<Habitacion> _dbSet;
        public HabitacionRepository(SGHRContext context, ILogger<HabitacionRepository> logger)
        {
            _context = context;
            _logger = logger;
            _dbSet = context.Set<Habitacion>();
        }
        public async Task<OperationResult<HabitacionModel>> CreateAsync(HabitacionModel modelo)
        {
            OperationResult<HabitacionModel> result = new OperationResult<HabitacionModel>();

            _logger.LogInformation("Proceso para crear una habitacion");

            try
            {
                var Habitacion = new Habitacion
                {
                    IdHabitacion = modelo.IdHabitacion,
                    Numero = modelo.Numero,
                    Detalle = modelo.Detalle,
                    Precio = modelo.Precio,
                    IdEstadoHabitacion = modelo.IdEstadoHabitacion,
                    IdPiso = modelo.IdPiso,
                    IdCategoria = modelo.IdCategoria,
                    UsuarioCreacion = modelo.UsuarioCreacion,
                    FechaCreacion = DateTime.Now,
                    Estado = true
                };

                await _dbSet.AddAsync(Habitacion);
                await _context.SaveChangesAsync();

                var HabitacionModel = new HabitacionModel
                {
                    IdHabitacion = modelo.IdHabitacion,
                    Numero = modelo.Numero,
                    Detalle = modelo.Detalle,
                    Precio = modelo.Precio,
                    IdEstadoHabitacion = modelo.IdEstadoHabitacion,
                    IdPiso = modelo.IdPiso,
                    IdCategoria = modelo.IdCategoria,
                    UsuarioCreacion = modelo.UsuarioCreacion,
                    FechaCreacion = DateTime.Now,
                    Estado = true
                };

                result = OperationResult<HabitacionModel>.Succes("Datos agregados correctamente", HabitacionModel);
                _logger.LogInformation("Datos ingresados correctamente");
            }
            catch (Exception e) 
            {
                result = OperationResult<HabitacionModel>.Failure("Error ingresando los datos" + e.Message);
                _logger.LogError("Error ingrsando los datos" + e.Message);
            }
            return result;
        }

        public async Task<OperationResult<HabitacionModel>> DeleteAsync(int Id, int IdUsuario)
        {
            OperationResult<HabitacionModel> result = new OperationResult<HabitacionModel>();
            _logger.LogInformation("Proceso para eliminar los datos");

            try
            {
                var habitacion = await _dbSet.FirstOrDefaultAsync(c => c.IdHabitacion == Id || c.UsuarioEliminacion == IdUsuario);

                if (habitacion == null)
                    return result = OperationResult<HabitacionModel>.Failure("Datos a eliminar no encontrados");

                habitacion.Borrado = true;
                habitacion.Estado = false;
                habitacion.UsuarioEliminacion = IdUsuario;
                habitacion.FechaEliminado = DateTime.Now;

                _dbSet.Update(habitacion);
                await _context.SaveChangesAsync();

                result = OperationResult<HabitacionModel>.Succes("Datos eliminados correctamente");
                _logger.LogInformation("Datos eliminados correctamente");
            }
            catch (Exception e) 
            {
                result = OperationResult<HabitacionModel>.Failure("Error eliminando los datos" + e.Message);
                _logger.LogError("Error erliminando los datos" + e.Message);
            }
            return result;
        }

        public async Task<OperationResult<IEnumerable<HabitacionModel>>> GetAllAsync()
        {
            OperationResult<IEnumerable<HabitacionModel>> result = new OperationResult<IEnumerable<HabitacionModel>>();

            _logger.LogInformation("Proceso para mostrar las habitaciones");

            try
            {
                var habitacion = await _dbSet.ToListAsync();

                var habitaciones = habitacion.Select(c => new HabitacionModel
                {
                    IdHabitacion = c.IdHabitacion,
                    Numero = c.Numero,
                    Detalle = c.Detalle,
                    Precio = c.Precio,
                    IdEstadoHabitacion = c.IdEstadoHabitacion,
                    IdPiso = c.IdPiso,
                    IdCategoria = c.IdCategoria,
                    Estado = c.Estado,
                    UsuarioCreacion = c.UsuarioCreacion,
                    FechaCreacion = c.FechaCreacion,
                    UsuarioEliminacion = c.UsuarioEliminacion,
                    FechaEliminado = c.FechaActualizacion,
                    UsuarioActualizacion = c.UsuarioActualizacion,
                    FechaActualizacion = c.FechaActualizacion,
                    Borrado = c.Borrado
                });

                if (habitaciones == null)
                    return result = OperationResult<IEnumerable<HabitacionModel>>.Failure("No se encontraron los datos");

                result = OperationResult<IEnumerable<HabitacionModel>>.Succes("Datos cargados corretamente", habitaciones);
                _logger.LogInformation("Datos cargados correctamente");
            }
            catch (Exception e) 
            {
                result = OperationResult<IEnumerable<HabitacionModel>>.Failure("Error cargando los datos" + e.Message);
                _logger.LogError("Error cargando los datos" + e.Message);
            }
            return result;
        }

        public async Task<OperationResult<HabitacionModel>> GetByIdAsync(int Id)
        {
            OperationResult<HabitacionModel> result = new OperationResult<HabitacionModel>();

            _logger.LogInformation("Cargando los datos por ID");

            try
            {
                var habitacion = await _dbSet.Where(c => c.IdHabitacion == Id).Select(c => new HabitacionModel 
                {
                    IdHabitacion = c.IdHabitacion,
                    Numero = c.Numero,
                    Detalle = c.Detalle,
                    Precio = c.Precio,
                    IdEstadoHabitacion = c.IdEstadoHabitacion,
                    IdPiso = c.IdPiso,
                    IdCategoria = c.IdCategoria,
                    Estado = c.Estado,
                    UsuarioCreacion = c.UsuarioCreacion,
                    FechaCreacion = c.FechaCreacion,
                    UsuarioEliminacion = c.UsuarioEliminacion,
                    FechaEliminado = c.FechaActualizacion,
                    UsuarioActualizacion = c.UsuarioActualizacion,
                    FechaActualizacion = c.FechaActualizacion,
                    Borrado = c.Borrado
                }).FirstOrDefaultAsync();

                if (habitacion == null)
                    return result = OperationResult<HabitacionModel>.Failure("No se encontraron los datos");

                result = OperationResult<HabitacionModel>.Succes("Datos por ID cargados correctamente", habitacion);
                _logger.LogInformation("Datos por ID cargados correctamente");
            }
            
            catch (Exception e) 
            {
                result = OperationResult<HabitacionModel>.Failure("Error cargand olos datos por ID" + e.Message);
                _logger.LogError("Error cargand olos datos por ID" + e.Message);
            }
            return result;
        }

        public async Task<OperationResult<HabitacionModel>> UpdateAsync(HabitacionModel modelo)
        {
            OperationResult<HabitacionModel> result = new OperationResult<HabitacionModel>();

            _logger.LogInformation("Proceso para actualizar una habitacion");

            try
            {
                if (modelo == null || modelo.IdHabitacion == null || modelo.UsuarioActualizacion == null)
                    return result = OperationResult<HabitacionModel>.Failure("Datos a actualizar no encontrados");


                var habitacion = await _dbSet.FirstOrDefaultAsync(c => c.IdHabitacion == modelo.IdHabitacion || c.UsuarioActualizacion == modelo.UsuarioActualizacion);

                habitacion.Numero = modelo.Numero;
                habitacion.Detalle = modelo.Detalle;
                habitacion.Precio = modelo.Precio;
                habitacion.IdEstadoHabitacion = modelo.IdEstadoHabitacion;
                habitacion.IdPiso = modelo.IdPiso;
                habitacion.IdCategoria = modelo.IdCategoria;

                habitacion.UsuarioActualizacion = modelo.UsuarioActualizacion;
                habitacion.FechaActualizacion = DateTime.Now;

                _dbSet.Update(habitacion);
                await _context.SaveChangesAsync();

                result = OperationResult<HabitacionModel>.Succes("Datos actualizado correctamente");
                _logger.LogInformation("Datos cargados correctamente");
            }
            catch (Exception e) 
            {
                result = OperationResult<HabitacionModel>.Failure("Error actaulizando los datos" +e.Message);
                _logger.LogError("Error cargand olos datos" + e.Message);
            }
            return result;

        }
    }
}
