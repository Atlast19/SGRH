
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGRH.Domein.Base;
using SGRH.Domein.Interfaces.Usuarios;
using SGRH.Domein.Models.Usuarios;
using SGRH.Percistence.Context;
using System.Reflection.Emit;

namespace SGRH.Percistence.Repository.Usuarios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SGHRContext _context;
        private readonly ILogger<UsuarioRepository> _logger;
        DbSet<Domein.Entitys.Usuario> _dbSet;
        public UsuarioRepository(SGHRContext context, ILogger<UsuarioRepository> logger)
        {
            _context = context;
            _logger = logger;
            _dbSet = context.Set<SGRH.Domein.Entitys.Usuario>();
        }

        public Task<OperationResult<UsuarioModel>> CreateAsync(UsuarioModel modelo)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult<UsuarioModel>> DeleteAsync(int Id, int IdUsuario)
        {
            OperationResult<UsuarioModel> result = new OperationResult<UsuarioModel>();

            _logger.LogInformation("Eliminando usuario");
            try
            {
                var usuaro = await _dbSet.FirstOrDefaultAsync(c => c.IdUsuario == Id);

                if (usuaro == null || IdUsuario == null)
                    return result = OperationResult<UsuarioModel>.Failure("No se encontro el usuario a eliminar");

                usuaro.Estado = false;
                usuaro.Borrado = true;
                usuaro.UsuarioCreacion = IdUsuario;
                usuaro.FechaEliminado = DateTime.Now;

                _dbSet.Update(usuaro);
                await _context.SaveChangesAsync();

                result = OperationResult<UsuarioModel>.Succes("Usuario eliminado correctamente");
                _logger.LogInformation("Usuario eliminado correctamente");

            }
            catch (Exception e) 
            {
                result = OperationResult<UsuarioModel>.Failure("Error eliminando el usuario" + e);
                _logger.LogError("Error eliminando el usuario por ID" + e);
            }
            return result;
        }

        public async Task<OperationResult<IEnumerable<UsuarioModel>>> GetAllAsync()
        {
            OperationResult<IEnumerable<UsuarioModel>> result = new OperationResult<IEnumerable<UsuarioModel>>();

            _logger.LogInformation("Cargando todos los datos de los usuarios");
            try
            {
                var usuarios = await _dbSet.ToListAsync();

                var usuario = usuarios.Select(u => new UsuarioModel
                {
                    IdUsuario = u.IdUsuario,
                    NombreCompleto = u.NombreCompleto,
                    Correo = u.Correo,
                    IdRolUsuario = u.IdRolUsuario,
                    Clave = u.Clave,
                    Estado = u.Estado,
                    UsuarioCreacion = u.UsuarioCreacion,
                    FechaCreacion = u.FechaCreacion,
                    UsuarioEliminacion = u.UsuarioEliminacion,
                    FechaEliminado = u.FechaEliminado,
                    Borrado = u.Borrado,
                    UsuarioActualizacion = u.UsuarioActualizacion,
                    FechaActualizacion = u.FechaActualizacion
                });

                if (usuario == null)
                    return result = OperationResult<IEnumerable<UsuarioModel>>.Failure("No se encontraron los datos de ningun usuario");

                result = OperationResult<IEnumerable<UsuarioModel>>.Succes("Datos cargados correctamente", usuario);
                _logger.LogInformation("Datos de los usuarios cargados correctamente");
            }
            catch (Exception e) 
            {
                result = OperationResult<IEnumerable<UsuarioModel>>.Failure("Error Cargando los datos" + e);
                _logger.LogError("Error cargando los datos de los usuarios" + e);
            }
            return result;
        }

        public async Task<OperationResult<UsuarioModel>> GetByIdAsync(int Id)  
        {
            OperationResult<UsuarioModel> result = new OperationResult<UsuarioModel>();

            _logger.LogInformation("Cargando usuario por ID");
            try
            {
                var usuario = _dbSet.Where(c => c.IdUsuario == Id).Select(c => new UsuarioModel
                {
                    IdUsuario = c.IdUsuario,
                    NombreCompleto = c.NombreCompleto,
                    Correo = c.Correo,
                    IdRolUsuario = c.IdUsuario,
                    Clave = c.Clave,
                    Estado = c.Estado,
                    UsuarioCreacion = c.UsuarioCreacion,
                    FechaCreacion = c.FechaCreacion,
                    UsuarioEliminacion = c.UsuarioEliminacion,
                    FechaEliminado = c.FechaEliminado,
                    Borrado = c.Borrado,
                    UsuarioActualizacion = c.UsuarioActualizacion,
                    FechaActualizacion = c.FechaActualizacion

                }).FirstOrDefaultAsync();

                if (usuario == null)
                    return result = OperationResult<UsuarioModel>.Failure("No se encontro el usuario solicitado");

                result = OperationResult<UsuarioModel>.Succes("Datos del usuario cargados correctamente", usuario);
                _logger.LogInformation("Usuario por ID cargado correctamente");
            }
            catch (Exception e) 
            {
                result = OperationResult<UsuarioModel>.Failure("Error cargando los datos del usuario" + e);
                _logger.LogError("Error cargando el usuario por ID");
            }
            return result;
        }

        public Task<OperationResult<UsuarioModel>> UpdateAsync(UsuarioModel modelo)
        {
            throw new NotImplementedException();
        }
    }
}
