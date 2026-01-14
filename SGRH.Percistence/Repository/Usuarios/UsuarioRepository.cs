using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGRH.Domein.Interfaces.Usuarios;
using SGRH.Percistence.Context;

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
            _dbSet = context.Set<Domein.Entitys.Usuario>();
        }

        public async Task CreateAsync(Domein.Entitys.Usuario Entity)
        {


            _logger.LogInformation("Proceso de crear un usuario");
            
            await _dbSet.AddAsync(Entity);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int Id, int IdUsuario)
        {

            _logger.LogInformation("Eliminando usuario");
            
            var usuaro = await _dbSet.FirstOrDefaultAsync(c => c.IdUsuario == Id && !c.Borrado);
            
            usuaro.Estado = false;
            usuaro.Borrado = true;
            usuaro.UsuarioCreacion = IdUsuario;
            usuaro.FechaEliminado = DateTime.Now;

            _dbSet.Update(usuaro);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Domein.Entitys.Usuario>> GetAllAsync()
        {

            _logger.LogInformation("Cargando todos los datos de los usuarios");
            
            return await _dbSet.ToListAsync();

        }

        public async Task<Domein.Entitys.Usuario?> GetByIdAsync(int Id)  
        {

            _logger.LogInformation("Cargando usuario por ID");
            
            return await _dbSet.FirstOrDefaultAsync(c => c.IdUsuario == Id && !c.Borrado);
        }

        public async Task UpdateAsync(Domein.Entitys.Usuario Entity)
        {

            _logger.LogInformation("Proceso para actualizar un usuario");

            var usuairo = await _dbSet.FirstOrDefaultAsync(c => c.IdUsuario == Entity.IdUsuario && !c.Borrado);
            
            usuairo.NombreCompleto = Entity.NombreCompleto;
            usuairo.Correo = Entity.Correo;
            usuairo.Clave = Entity.Clave;
            usuairo.IdRolUsuario = Entity.IdRolUsuario;
            usuairo.UsuarioActualizacion = Entity.UsuarioActualizacion;
            usuairo.FechaActualizacion = DateTime.Now;

            _dbSet.Update(usuairo);
            await _context.SaveChangesAsync();

        }
    }
}
