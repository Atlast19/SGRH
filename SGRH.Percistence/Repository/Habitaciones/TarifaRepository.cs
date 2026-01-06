

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGRH.Domein.Base;
using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Habitaciones;
using SGRH.Domein.Models.Habitaciones;
using SGRH.Percistence.Context;
using System.Reflection.Metadata.Ecma335;

namespace SGRH.Percistence.Repository.Habitaciones
{
    public class TarifaRepository : ITarifaRepository
    {
        private readonly SGHRContext _context;
        private readonly ILogger<TarifaRepository> _logger;
        DbSet<Tarifa> _dbSet;
        public TarifaRepository(SGHRContext context, ILogger<TarifaRepository> logger)
        {
            _context = context;
            _logger = logger;
            _dbSet = context.Set<Tarifa>();
        }
        public async Task<OperationResult<TarifaModel>> CreateAsync(TarifaModel modelo)
        {
            OperationResult<TarifaModel> result = new OperationResult<TarifaModel>();
            _logger.LogInformation("Proceso para crear una tarifa");

            try
            {
                var tarifa = new Tarifa 
                {
                    IdTarifa = modelo.IdTarifa,
                    IdHabitacion = modelo.IdHabitacion,
                    FechaInicio = modelo.FechaInicio,
                    FechaFin = modelo.FechaFin,
                    PrecioPorNoche = modelo.PrecioPorNoche,
                    Descuento = modelo.Descuento,
                    Descripcion = modelo.Descripcion,
                    UsuarioCreacion = modelo.UsuarioCreacion,
                    FechaCreacion = DateTime.Now,
                    Estado = true
                };

                _dbSet.AddAsync(tarifa);
                await _context.SaveChangesAsync();

                var tarifaModel = new TarifaModel 
                {
                    IdTarifa = modelo.IdTarifa,
                    IdHabitacion = modelo.IdHabitacion,
                    FechaInicio = modelo.FechaInicio,
                    FechaFin = modelo.FechaFin,
                    PrecioPorNoche = modelo.PrecioPorNoche,
                    Descuento = modelo.Descuento,
                    Descripcion = modelo.Descripcion,
                    UsuarioCreacion = modelo.UsuarioCreacion,
                    FechaCreacion = DateTime.Now,
                    Estado = true
                };

                result = OperationResult<TarifaModel>.Succes("Datos agregados correctamente", tarifaModel);
                _logger.LogInformation("Datos agregados correctamente");
            }
            catch (Exception e) 
            {
                result = OperationResult<TarifaModel>.Failure("Error agregando los datos" + e.Message);
                _logger.LogError("Error agregando los datos" + e.Message);
            }
            return result;
        }

        public async Task<OperationResult<TarifaModel>> DeleteAsync(int Id, int IdUsuario)
        {
            OperationResult<TarifaModel> result = new OperationResult<TarifaModel>();
            _logger.LogInformation("Proceso para eliminar una tarifa");

            try
            {
                var tarifa = await _dbSet.FirstOrDefaultAsync(c => c.IdTarifa == Id || c.UsuarioCreacion == IdUsuario);

                if (tarifa == null)
                    return result = OperationResult<TarifaModel>.Failure("No se encontraron los datos a eliminar");

                tarifa.Estado = false;
                tarifa.Borrado = true;
                tarifa.FechaEliminado = DateTime.Now;
                tarifa.UsuarioEliminacion = IdUsuario;

                _dbSet.Update(tarifa);
                await _context.SaveChangesAsync();

                result = OperationResult<TarifaModel>.Succes("Datos eliminados correctamente");
                _logger.LogInformation("Datos eliminados correctamente");
            }
            catch (Exception e) 
            {
                result = OperationResult<TarifaModel>.Failure("Error eliminando los datos" + e.Message);
                _logger.LogError("Error eliminando los datos" + e.Message);
            }
            return result;
        }

        public async Task<OperationResult<IEnumerable<TarifaModel>>> GetAllAsync()
        {
            OperationResult<IEnumerable<TarifaModel>> result = new OperationResult<IEnumerable<TarifaModel>>();
            _logger.LogInformation("Proceso para cargar todas las tarifas");

            try
            {
                var tarifa = await _dbSet.ToListAsync();

                var tarifaModel = tarifa.Select(c => new TarifaModel
                {
                    IdTarifa = c.IdTarifa,
                    IdHabitacion = c.IdHabitacion,
                    FechaInicio = c.FechaInicio,
                    FechaFin = c.FechaFin,
                    PrecioPorNoche = c.PrecioPorNoche,
                    Descuento = c.Descuento,
                    Descripcion = c.Descripcion,
                    UsuarioCreacion = c.UsuarioCreacion,
                    UsuarioActualizacion = c.UsuarioActualizacion,
                    UsuarioEliminacion = c.UsuarioEliminacion,
                    FechaCreacion = c.FechaCreacion,
                    FechaEliminado = c.FechaEliminado,
                    FechaActualizacion = c.FechaActualizacion,
                    Estado = c.Estado,
                    Borrado = c.Borrado
                });

                if (tarifaModel == null)
                    return result = OperationResult<IEnumerable<TarifaModel>>.Failure("Error cargando todos los datos");

                result = OperationResult<IEnumerable<TarifaModel>>.Succes("Datos cargados correctamente", tarifaModel);
                _logger.LogInformation("Datos cargados correctamente");
            }
            catch (Exception e) 
            {
                result = OperationResult<IEnumerable<TarifaModel>>.Failure("Error cargando los datos" + e.Message);
                _logger.LogError("Error cargando los datos" + e.Message);
            }
            return result;
        }

        public async Task<OperationResult<TarifaModel>> GetByIdAsync(int Id)
        {
            OperationResult<TarifaModel> result = new OperationResult<TarifaModel>();
            _logger.LogInformation("Proceso para cargar las tarifas por ID");

            try
            {
                var tarifa = await _dbSet.Where(c => c.IdTarifa == Id).Select(c => new TarifaModel 
                {
                    IdTarifa = c.IdTarifa,
                    IdHabitacion = c.IdHabitacion,
                    FechaInicio = c.FechaInicio,
                    FechaFin = c.FechaFin,
                    PrecioPorNoche = c.PrecioPorNoche,
                    Descuento = c.Descuento,
                    Descripcion = c.Descripcion,
                    UsuarioCreacion = c.UsuarioCreacion,
                    UsuarioActualizacion = c.UsuarioActualizacion,
                    UsuarioEliminacion = c.UsuarioEliminacion,
                    FechaCreacion = c.FechaCreacion,
                    FechaEliminado = c.FechaEliminado,
                    FechaActualizacion = c.FechaActualizacion,
                    Estado = c.Estado,
                    Borrado = c.Borrado
                }).FirstOrDefaultAsync();

                if (tarifa == null)
                    return result = OperationResult<TarifaModel>.Failure("No se encontraron los datos");

                result = OperationResult<TarifaModel>.Succes("Datos por ID cargados correctamente", tarifa);
                _logger.LogInformation("Datos por ID cargados correctamente");
            }
            catch (Exception e) 
            {
                result = OperationResult<TarifaModel>.Failure("Error cargando los datos por ID" + e.Message);
                _logger.LogError("Error cargando los datos por ID" + e.Message);
            }
            return result;
        }

        public async Task<OperationResult<TarifaModel>> UpdateAsync(TarifaModel modelo)
        {
            OperationResult<TarifaModel> result = new OperationResult<TarifaModel>();
            _logger.LogInformation("Proceso para actializar ");

            try
            {
                if (modelo == null || modelo.IdTarifa == null || modelo.UsuarioActualizacion == null)
                    return result = OperationResult<TarifaModel>.Failure("No se encontraron los datos a actualizar");

                var tarifa = await _dbSet.FirstOrDefaultAsync(c => c.IdTarifa == modelo.IdTarifa || c.UsuarioActualizacion == modelo.UsuarioActualizacion);

                tarifa.IdHabitacion = modelo.IdHabitacion;
                tarifa.FechaInicio = modelo.FechaInicio;
                tarifa.FechaFin = modelo.FechaFin;
                tarifa.PrecioPorNoche = modelo.PrecioPorNoche;
                tarifa.Descuento = modelo.Descuento;
                tarifa.Descripcion = modelo.Descripcion;
                tarifa.UsuarioActualizacion = modelo.UsuarioActualizacion;
                tarifa.FechaActualizacion = DateTime.Now;

                _dbSet.Update(tarifa);
                await _context.SaveChangesAsync();

                result = OperationResult<TarifaModel>.Succes("Datos actualizados correcamente");
                _logger.LogInformation("Datos actualizados correctamente");
            }
            catch (Exception e) 
            {
                result = OperationResult<TarifaModel>.Failure("Error actualizando los datos" + e.Message);
                _logger.LogError("Error actualizando los datos" + e.Message);
            }
            return result;
        }
    }
}
