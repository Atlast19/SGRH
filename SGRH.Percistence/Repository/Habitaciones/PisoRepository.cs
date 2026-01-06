

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGRH.Domein.Base;
using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Habitaciones;
using SGRH.Domein.Models.Habitaciones;
using SGRH.Percistence.Context;
using System.Net.Http.Headers;

namespace SGRH.Percistence.Repository.Habitaciones
{
    public class PisoRepository : IPisoRepository
    {
        private readonly SGHRContext _context;
        private readonly ILogger<PisoRepository> _logger;
        DbSet<Piso> _dbSet;
        public PisoRepository(SGHRContext context, ILogger<PisoRepository> logger)
        {
            _context = context;
            _logger = logger;
            _dbSet = context.Set<Piso>();
        }

        public async Task<OperationResult<PisoModel>> CreateAsync(PisoModel modelo)
        {
            OperationResult<PisoModel> result = new OperationResult<PisoModel>();
            _logger.LogInformation("Proceso para crear un piso");

            try
            {
                var piso = new Piso
                {
                    IdPiso = modelo.IdPiso,
                    Descripcion = modelo.Descripcion,
                    UsuarioCreacion = modelo.UsuarioCreacion,
                    FechaCreacion = DateTime.Now
                };

                _dbSet.AddAsync(piso);
                await _context.SaveChangesAsync();

                var pisoModel = new PisoModel 
                {
                    IdPiso = modelo.IdPiso,
                    Descripcion = modelo.Descripcion,
                    UsuarioCreacion = modelo.UsuarioCreacion,
                    FechaCreacion = DateTime.Now
                };

                result = OperationResult<PisoModel>.Succes("Datos ingresados correctamente", pisoModel);
                _logger.LogInformation("Datos agregados correctamente");
            }
            catch (Exception e) 
            {
                result = OperationResult<PisoModel>.Failure("Error agregando los datos" + e.Message);
                _logger.LogError("Error agregando los datos" + e.Message);
            }
            return result;
        }

        public async Task<OperationResult<PisoModel>> DeleteAsync(int Id, int IdUsuario)
        {
            OperationResult<PisoModel> result = new OperationResult<PisoModel>();
            _logger.LogInformation("Proceso para eliminar los datos");

            try
            {
                var Piso = await _dbSet.FirstOrDefaultAsync(c => c.IdPiso == Id || c.UsuarioEliminacion == IdUsuario);

                if (Piso == null)
                    return result = OperationResult<PisoModel>.Failure("No se encontraron los datos a eliminar");

                Piso.Estado = false;
                Piso.Borrado = true;
                Piso.FechaEliminado = DateTime.Now;
                Piso.UsuarioEliminacion = IdUsuario;

                _dbSet.Update(Piso);
                await _context.SaveChangesAsync();

                result = OperationResult<PisoModel>.Succes("Datos eliminados correctamente");
                _logger.LogInformation("Datos eliminados correctamente");
            }
            catch (Exception e) 
            {
                result = OperationResult<PisoModel>.Failure("Error eliminando los datos" + e.Message);
                _logger.LogError("Error eliminando los datos" + e.Message);
            }
            return result;
        }

        public async Task<OperationResult<IEnumerable<PisoModel>>> GetAllAsync()
        {
            OperationResult<IEnumerable<PisoModel>> result = new OperationResult<IEnumerable<PisoModel>>();
            _logger.LogInformation("Proceso para cargar los datos de piso");

            try
            {
                var piso = await _dbSet.ToListAsync();

                var pisoModel = piso.Select(c => new PisoModel
                {
                    IdPiso = c.IdPiso,
                    Descripcion = c.Descripcion,
                    Estado = c.Estado,
                    UsuarioCreacion = c.UsuarioCreacion,
                    FechaCreacion = c.FechaCreacion,
                    UsuarioEliminacion = c.UsuarioEliminacion,
                    FechaEliminado = c.FechaEliminado,
                    UsuarioActualizacion = c.UsuarioActualizacion,
                    FechaActualizacion = c.FechaActualizacion
                });

                if (pisoModel == null)
                    return result = OperationResult<IEnumerable<PisoModel>>.Failure("no se encontraron los datos");

                result = OperationResult<IEnumerable<PisoModel>>.Succes("Datos cargados correctamente", pisoModel);
                _logger.LogInformation("Datos cargados correctamente");
            }
            catch (Exception e) 
            {
                result = OperationResult<IEnumerable<PisoModel>>.Failure("Error cargando los datos" + e.Message);
                _logger.LogError("Error cargando los datos" + e.Message);
            }
            return result;
        }

        public async Task<OperationResult<PisoModel>> GetByIdAsync(int Id)
        {
            OperationResult<PisoModel> result = new OperationResult<PisoModel>();
            _logger.LogInformation("Proceso para cargar los datos por ID");

            try
            {
                var piso = await _dbSet.Where(c => c.IdPiso == Id).Select(c => new PisoModel 
                {
                    IdPiso = c.IdPiso,
                    Descripcion = c.Descripcion,
                    Estado = c.Estado,
                    UsuarioCreacion = c.UsuarioCreacion,
                    FechaCreacion = c.FechaCreacion,
                    UsuarioEliminacion = c.UsuarioEliminacion,
                    FechaEliminado = c.FechaEliminado,
                    UsuarioActualizacion = c.UsuarioActualizacion,
                    FechaActualizacion = c.FechaActualizacion
                }).FirstOrDefaultAsync();

                if (piso == null)
                    return result = OperationResult<PisoModel>.Failure("No se encontraron los datos");

                result = OperationResult<PisoModel>.Succes("Datos cargados correctamente", piso);
                _logger.LogInformation("Datos cargados correctamente ");
            }
            catch (Exception e) 
            {
                result = OperationResult<PisoModel>.Failure("No se encontraron los datos" + e.Message);
                _logger.LogError("Error cargando los datos" + e.Message);
            }
            return result;
        }

        public async Task<OperationResult<PisoModel>> UpdateAsync(PisoModel modelo)
        {
            OperationResult<PisoModel> result = new OperationResult<PisoModel>();
            _logger.LogInformation("Proceso para actualizar un pido");

            try
            {
                if (modelo == null || modelo.IdPiso == null || modelo.UsuarioActualizacion == null)
                    return result = OperationResult<PisoModel>.Failure("Datos a actualizar no encontrados");

                var piso = await _dbSet.FirstOrDefaultAsync(c => c.IdPiso == modelo.IdPiso || c.UsuarioActualizacion == modelo.UsuarioActualizacion);

                piso.Descripcion = modelo.Descripcion;
                piso.UsuarioActualizacion = modelo.UsuarioActualizacion;
                piso.FechaActualizacion = DateTime.Now;

                _dbSet.Update(piso);
                await _context.SaveChangesAsync();

                result = OperationResult<PisoModel>.Succes("Datos actalizados correctamente");
                _logger.LogInformation("Datos actualizados correctamente");
            }
            catch (Exception e) 
            {
                result = OperationResult<PisoModel>.Failure("Error actualizando los datos" + e.Message);
                _logger.LogError("Error actaulizando los datos" + e.Message);
            }
            return result;
        }
    }
}
