

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Usuarios;
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

        public async Task CreateAsync(RolUsuario Entity)
        {

            _logger.LogInformation("Proceso para crear un rol de usuario");
            
            await _dbSet.AddAsync(Entity);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int Id, int IdUsuario)
        {

            _logger.LogInformation("Proceso para eliminar un rol");
            
            var RolUsuario = await _dbSet.FirstOrDefaultAsync(c => c.IdRolUsuario == Id && ! c.Borrado);
            
            RolUsuario.Borrado = true;
            RolUsuario.Estado = false;
            RolUsuario.UsuarioEliminacion = IdUsuario;
            RolUsuario.FechaEliminado = DateTime.Now;

            _dbSet.Update(RolUsuario);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<RolUsuario>> GetAllAsync()
        {

            _logger.LogInformation("Procesando los roles de los usuarios");

            return await _dbSet.ToListAsync();

        }

        public async Task<RolUsuario?> GetByIdAsync(int Id)
        {

            _logger.LogInformation("Proceso de cargar los roles de los usuarios por ID");

            return await _dbSet.FirstOrDefaultAsync(c => c.IdRolUsuario == Id && !c.Borrado);

        }

        public async Task UpdateAsync(RolUsuario modelo)
        {

            _logger.LogInformation("Proceso para actualizar los datos");
            
            var RolUsuario = await _dbSet.FirstOrDefaultAsync(c => c.IdRolUsuario == modelo.IdRolUsuario && !c.Borrado);
            
            RolUsuario.Descripcion = modelo.Descripcion;
            RolUsuario.UsuarioActualizacion = modelo.UsuarioActualizacion;
            RolUsuario.FechaActualizacion = DateTime.Now;
            
            _dbSet.Update(RolUsuario);
            await _context.SaveChangesAsync();

        }
    }
}
