

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGRH.Domein.Base;
using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Usuarios;
using SGRH.Domein.Models.Usuarios;
using SGRH.Percistence.Context;

namespace SGRH.Percistence.Repository.Usuarios
{
    public class RolUsuarioRepository : IRolUsuarioRepository
    {
        private readonly SGHRContext _context;
        private readonly ILogger<RolUsuarioRepository> _logger;
        DbSet<RolUsuario> _dbSet;

        public RolUsuarioRepository(SGHRContext context, ILogger<RolUsuarioRepository> logger)
        {
            _context = context;
            _logger = logger;
            _dbSet = context.Set<RolUsuario>();
        }

        public async Task<OperationResult<RolUsuarioModel>> CreateAsync(RolUsuarioModel modelo)
        {
            OperationResult<RolUsuarioModel> result = new OperationResult<RolUsuarioModel>();

            _logger.LogInformation("Proceso para crear un rol de usuario");
            try
            {
                var RolUsuario = new RolUsuario
                {
                    IdRolUsuario = modelo.IdRolUsuario,
                    Descripcion = modelo.Descripcion,
                    UsuarioCreacion = modelo.UsuarioCreacion,
                    FechaCreacion = DateTime.Now
                };

                await _dbSet.AddAsync(RolUsuario);
                await _context.SaveChangesAsync();

                var RolUsuarioModel = new RolUsuarioModel
                {
                    IdRolUsuario = modelo.IdRolUsuario,
                    Descripcion = modelo.Descripcion,
                    UsuarioCreacion = modelo.UsuarioCreacion,
                    FechaCreacion = DateTime.Now
                };

                result = OperationResult<RolUsuarioModel>.Succes("Rol de usuario creado correctamdente", RolUsuarioModel);
                _logger.LogInformation("Rol de usuario creado correctamente");
            }
            catch (Exception e) 
            {
                result = OperationResult<RolUsuarioModel>.Failure("Error al crear el Rol del usuario" + e.Message);
                _logger.LogError("Error al crear el Rol del usuario" + e.Message);
            }
            return result;
        }

        public async Task<OperationResult<RolUsuarioModel>> DeleteAsync(int Id, int IdUsuario)
        {
            OperationResult<RolUsuarioModel> result = new OperationResult<RolUsuarioModel>();

            _logger.LogInformation("Proceso para eliminar un rol");
            try
            {
                var RolUsuario = await _dbSet.FirstOrDefaultAsync(c => c.IdRolUsuario == Id);

                if (RolUsuario == null || IdUsuario == null)
                    return result = OperationResult<RolUsuarioModel>.Failure("No se encontraron los datos");

                RolUsuario.Borrado = true;
                RolUsuario.Estado = false;
                RolUsuario.UsuarioEliminacion = IdUsuario;
                RolUsuario.FechaEliminado = DateTime.Now;

                _dbSet.Update(RolUsuario);
                await _context.SaveChangesAsync();

                result = OperationResult<RolUsuarioModel>.Succes("Rol del usuario eliminado correctamente", RolUsuario);
                _logger.LogInformation("Rol eliminado correctamente");
            }
            catch (Exception e) 
            {
                result = OperationResult<RolUsuarioModel>.Failure("Error al eliminar los doats" + e.Message);
                _logger.LogError("Error al eliminar los doats" + e.Message);
            }
            return result;
        }

        public async Task<OperationResult<IEnumerable<RolUsuarioModel>>> GetAllAsync()
        {
            OperationResult<IEnumerable<RolUsuarioModel>> result = new OperationResult<IEnumerable<RolUsuarioModel>>();

            _logger.LogInformation("Procesando los roles de los usuarios");
            try
            {
                var Rolusuario = await _dbSet.ToListAsync();

                var RolusuarioModel = Rolusuario.Select(c => new RolUsuarioModel
                {
                    IdRolUsuario = c.IdRolUsuario,
                    Descripcion = c.Descripcion,
                    Estado = c.Estado,
                    UsuarioCreacion = c.UsuarioCreacion,
                    FechaCreacion = c.FechaCreacion,
                    Borrado = c.Borrado,
                    UsuarioActualizacion = c.UsuarioActualizacion,
                    UsuarioEliminacion = c.UsuarioEliminacion,
                    FechaActualizacion = c.FechaActualizacion,
                    FechaEliminado = c.FechaEliminado
                });

                if (RolusuarioModel == null)
                    return result = OperationResult<IEnumerable<RolUsuarioModel>>.Failure("No se encontraron los datos solicitados");

                result = OperationResult<IEnumerable<RolUsuarioModel>>.Succes("Datos cargados correctamente", RolusuarioModel);
                _logger.LogInformation("Datos cargado scorrectamente");
            }
            catch (Exception e) 
            {
                result = OperationResult<IEnumerable<RolUsuarioModel>>.Failure("Error cargando los datos" + e.Message);
                _logger.LogError("Error cargand olos datos"+ e.Message);
            }
            return result;
        }

        public async Task<OperationResult<RolUsuarioModel>> GetByIdAsync(int Id)
        {
            OperationResult<RolUsuarioModel> result = new OperationResult<RolUsuarioModel>();

            _logger.LogInformation("Proceso de cargar los roles de los usuarios por ID");
            try
            {
                var RolUsuario = await _dbSet.Where(c => c.IdRolUsuario == Id).Select(c => new RolUsuarioModel
                {
                    IdRolUsuario = c.IdRolUsuario,
                    Descripcion = c.Descripcion,
                    Estado = c.Estado,
                    UsuarioCreacion = c.UsuarioCreacion,
                    FechaCreacion = c.FechaCreacion,
                    Borrado = c.Borrado,
                    UsuarioActualizacion = c.UsuarioActualizacion,
                    UsuarioEliminacion = c.UsuarioEliminacion,
                    FechaActualizacion = c.FechaActualizacion,
                    FechaEliminado = c.FechaEliminado
                    
                }).FirstOrDefaultAsync();

                if (RolUsuario == null)
                    return result = OperationResult<RolUsuarioModel>.Failure("No se encontraron los datos solicitados");

                result = OperationResult<RolUsuarioModel>.Succes("Datos cargados correctamente", RolUsuario);
                _logger.LogInformation("Datos cargados correctamente");
            }
            catch (Exception e) 
            {
                result = OperationResult<RolUsuarioModel>.Failure("Error cargando los datos" + e.Message);
                _logger.LogError("Error cargand olos datos" + e.Message);
            }
            return result;
        }

        public async Task<OperationResult<RolUsuarioModel>> UpdateAsync(RolUsuarioModel modelo)
        {
            OperationResult<RolUsuarioModel> result = new OperationResult<RolUsuarioModel>();

            _logger.LogInformation("Proceso para actualizar los datos");
            try
            {
                if (modelo == null || modelo.IdRolUsuario == null || modelo.UsuarioActualizacion== null)
                    return result = OperationResult<RolUsuarioModel>.Failure("Raol no encontrado");

                var RolUsuario = await _dbSet.FirstOrDefaultAsync(c => c.IdRolUsuario == modelo.IdRolUsuario);



                RolUsuario.Descripcion = modelo.Descripcion;
                RolUsuario.UsuarioActualizacion = modelo.UsuarioActualizacion;
                RolUsuario.FechaActualizacion = DateTime.Now;

                _dbSet.Update(RolUsuario);
                await _context.SaveChangesAsync();

                result = OperationResult<RolUsuarioModel>.Succes("Datos Actualizados correctamente", RolUsuario);
                _logger.LogInformation("Datos actualizados correctamente");
            }
            catch (Exception e)
            {
                result = OperationResult<RolUsuarioModel>.Failure("Error Actualizando los datos" + e.Message);
            }
            return result;
        }
    }
}
