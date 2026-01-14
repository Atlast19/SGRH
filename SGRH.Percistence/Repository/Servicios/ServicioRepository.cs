
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGRH.Domein.Base;
using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Servicios;
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
        public async Task CreateAsync(Servicio Entity)
        {

            _logger.LogInformation("Proceso para crear un servicio");

            await _dbSet.AddAsync(Entity);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int Id, int IdUsuario)
        {

            _logger.LogInformation("Proceso para eliminar un servicio");

            var servicio = await _dbSet.FirstOrDefaultAsync(c => c.IdServicio == Id && !c.Borrado);

            servicio.UsuarioEliminacion = IdUsuario;
            servicio.Borrado = true;
            servicio.Estado = false;
            servicio.FechaEliminado = DateTime.Now;

            _dbSet.Update(servicio);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Servicio>> GetAllAsync()
        {

            _logger.LogInformation("Proceso para cargar todos los servicios");
            
            return await _dbSet.ToListAsync();

        }

        public async Task<Servicio?> GetByIdAsync(int Id)
        {


            _logger.LogInformation("Proceso de cargar el servicio por ID");


            return await _dbSet.FirstOrDefaultAsync(c => c.IdServicio == Id && !c.Borrado);
        }

        public async Task UpdateAsync(Servicio Entity)
        {

            _logger.LogInformation("Proceso para actualizar el servicio");
            
            var servicio = await _dbSet.FirstOrDefaultAsync(c => c.IdServicio == Entity.IdServicio && !c.Borrado);

            servicio.IdServicio = Entity.IdServicio;
            servicio.Nombre = Entity.Nombre;
            servicio.Descripcion = Entity.Descripcion;

            servicio.FechaActualizacion = DateTime.Now;
            servicio.UsuarioActualizacion = Entity.UsuarioActualizacion;

            _dbSet.Update(servicio);
            await _context.SaveChangesAsync();

        }
    }
}
