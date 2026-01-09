
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGRH.Domein.Base;
using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Habitaciones;
using SGRH.Domein.Models.Habitaciones;
using SGRH.Percistence.Context;

namespace SGRH.Percistence.Repository.Habitaciones
{
    public class CategoriumRepository : ICategoriumRepository
    {
        private readonly SGHRContext _context;
        private readonly ILogger<CategoriumRepository> _logger;
        DbSet<Categorium> _dbSet;
        public CategoriumRepository(SGHRContext context, ILogger<CategoriumRepository> logger)
        {
            _context = context;
            _logger = logger;
            _dbSet = context.Set<Categorium>();
        }
        public async Task<OperationResult<CategoriumModel>> CreateAsync(CategoriumModel modelo)
        {
            OperationResult<CategoriumModel> result = new OperationResult<CategoriumModel>();
            _logger.LogInformation("Proceso para crear una categoria");

            try
            {
                var categoria = new Categorium
                {
                    IdCategoria = modelo.IdCategoria,
                    Descripcion = modelo.Descripcion,
                    IdServicio = modelo.IdServicio,
                    UsuarioCreacion = modelo.UsuarioCreacion,
                    FechaCreacion = DateTime.Now,
                    Estado = true
                };

                _dbSet.AddAsync(categoria);
                await _context.SaveChangesAsync();

                var categoriaModel = new CategoriumModel
                {
                    IdCategoria = modelo.IdCategoria,
                    Descripcion = modelo.Descripcion,
                    IdServicio = modelo.IdServicio,
                    UsuarioCreacion = modelo.UsuarioCreacion,
                    FechaCreacion = DateTime.Now,
                    Estado = true
                };

                result = OperationResult<CategoriumModel>.Succes("Datos agregados correctamente", categoriaModel);
                _logger.LogInformation("Datos agregados correctmanete");
            }
            catch (Exception e) 
            {
                result = OperationResult<CategoriumModel>.Failure("Error agregando los datos" + e.Message);
                _logger.LogError("Error cargando los datos" + e.Message);
            }
            return result;
        }

        public async Task<OperationResult<CategoriumModel>> DeleteAsync(int Id, int IdUsuario)
        {
            OperationResult<CategoriumModel> result = new OperationResult<CategoriumModel>();
            _logger.LogInformation("Proceso parra eliminar una categoria");

            try
            {
                var categoria = await _dbSet.FirstOrDefaultAsync(c => c.IdCategoria == Id || c.UsuarioEliminacion == IdUsuario);

                if (categoria == null)
                    return result = OperationResult<CategoriumModel>.Failure("No se encontraron los datos a eliminar");

                categoria.Borrado = true;
                categoria.Estado = false;
                categoria.UsuarioEliminacion = IdUsuario;
                categoria.FechaEliminado = DateTime.Now;

                _dbSet.Update(categoria);
                await _context.SaveChangesAsync();

                result = OperationResult<CategoriumModel>.Succes("Datos eliminados correctamente");
                _logger.LogInformation("Datos eliminados correctamente");
            }
            catch (Exception e) 
            {
                result = OperationResult<CategoriumModel>.Failure("Error eliminando los datos" + e.Message);
                _logger.LogError("Error eliminando los datos" + e.Message);
            }
            return result;
        }

        public async Task<OperationResult<IEnumerable<CategoriumModel>>> GetAllAsync()
        {
            OperationResult<IEnumerable<CategoriumModel>> result = new OperationResult<IEnumerable<CategoriumModel>>();
            _logger.LogInformation("Proeso para cargar todas las categorias");

            try 
            {
                var categoria = await _dbSet.ToListAsync();

                var categoriaModel = categoria.Select(c => new CategoriumModel
                {
                    IdCategoria = c.IdCategoria,
                    Descripcion = c.Descripcion,
                    IdServicio = c.IdServicio,
                    Estado = c.Estado,
                    UsuarioCreacion = c.UsuarioCreacion,
                    FechaCreacion = c.FechaCreacion,
                    UsuarioEliminacion = c.UsuarioEliminacion,
                    FechaEliminado = c.FechaEliminado,
                    UsuarioActualizacion = c.UsuarioActualizacion,
                    FechaActualizacion = c.FechaActualizacion,
                    Borrado = c.Borrado
                });

                if (categoria == null)
                    return result = OperationResult<IEnumerable<CategoriumModel>>.Failure("No se encontraron los datos");

                result = OperationResult<IEnumerable<CategoriumModel>>.Succes("Datos cargados correctamente", categoriaModel);
                _logger.LogInformation("Datos cargados correctamentte");
            }
            catch (Exception e)
            {
                result = OperationResult<IEnumerable<CategoriumModel>>.Failure("Error cargando los datos" + e.Message);
                _logger.LogError("Error cargando los datos" + e.Message);
            }
            return result;
        }

        public async Task<OperationResult<CategoriumModel>> GetByIdAsync(int Id)
        {
            OperationResult<CategoriumModel> result = new OperationResult<CategoriumModel>();
            _logger.LogInformation("Proceso para cargar los datos por ID");

            try
            {
                var categoria = await _dbSet.Where(c => c.IdCategoria == Id).Select(c => new CategoriumModel 
                {
                    IdCategoria = c.IdCategoria,
                    Descripcion = c.Descripcion,
                    IdServicio = c.IdServicio,
                    Estado = c.Estado,
                    UsuarioCreacion = c.UsuarioCreacion,
                    FechaCreacion = c.FechaCreacion,
                    UsuarioEliminacion = c.UsuarioEliminacion,
                    FechaEliminado = c.FechaEliminado,
                    UsuarioActualizacion = c.UsuarioActualizacion,
                    FechaActualizacion = c.FechaActualizacion,
                    Borrado = c.Borrado
                }).FirstOrDefaultAsync();

                if (categoria == null)
                    return result = OperationResult<CategoriumModel>.Failure("No se encontraron los datos");
            }
            catch (Exception e) 
            {
                result = OperationResult<CategoriumModel>.Failure("Error cargando los datos por ID" + e.Message);
                _logger.LogError("Error cargando los datos" + e.Message);
            }
            return result;
        }

        public async Task<OperationResult<CategoriumModel>> UpdateAsync(CategoriumModel modelo)
        {
            OperationResult<CategoriumModel> result = new OperationResult<CategoriumModel>();
            _logger.LogInformation("Proceso para actualizar la categoria");

            try
            {
                if (modelo == null || modelo.IdCategoria == null || modelo.UsuarioActualizacion == null)
                    return result = OperationResult<CategoriumModel>.Failure("No se encontraron los datos a actualizar");

                var categoria = await _dbSet.FirstOrDefaultAsync(c => c.IdCategoria == modelo.IdCategoria || c.UsuarioActualizacion == modelo.UsuarioActualizacion);

                categoria.Descripcion = modelo.Descripcion;
                categoria.IdServicio = modelo.IdServicio;
                categoria.FechaActualizacion = DateTime.Now;
                categoria.UsuarioActualizacion = modelo.UsuarioActualizacion;

                _dbSet.Update(categoria);
                await _context.SaveChangesAsync();

                result = OperationResult<CategoriumModel>.Succes("Datos actualizados correctamente");
                _logger.LogInformation("Datos cargados correctmaente");
            }
            catch (Exception e) 
            {
                result = OperationResult<CategoriumModel>.Failure("Error actualizando los datos" +e.Message);
                _logger.LogError("Error actualizando los datos" +e.Message);
            }
            return result;
        }
    }
}
