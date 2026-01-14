
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Habitaciones;
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
        public async Task CreateAsync(EstadoHabitacion Entity)
        {
            _logger.LogInformation("Proceso para crear el estadod de una habitacion");
            
            await _dbSet.AddAsync(Entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id, int IdUsuario)
        {
            _logger.LogInformation("Proceso para eliminar el estado de una habitacion");

                var estadohabitacion = await _dbSet.FirstOrDefaultAsync(c => c.IdEstadoHabitacion == Id && !c.Borrado);

                estadohabitacion.Borrado = true;
                estadohabitacion.FechaEliminado = DateTime.Now;
                estadohabitacion.UsuarioEliminacion = IdUsuario;
                estadohabitacion.Estado = false;

                _dbSet.Update(estadohabitacion);
                await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<EstadoHabitacion>> GetAllAsync()
        {

            _logger.LogInformation("Proceso para cargar todos los estados de las habitaciones");
            
            return await _dbSet.ToListAsync();

        }

        public async Task<EstadoHabitacion?> GetByIdAsync(int Id)
        {

            _logger.LogInformation("Proceso para cargar los datos por ID");

            return await _dbSet.FirstOrDefaultAsync(c => c.IdEstadoHabitacion == Id && !c.Borrado);
                
        }

        public async Task UpdateAsync(EstadoHabitacion Entity)
        {

            _logger.LogInformation("Proceso para actualizar el estado de la habitacion");
            
            var estadohabitacion = await _dbSet.FirstOrDefaultAsync(c => c.IdEstadoHabitacion == Entity.IdEstadoHabitacion && !c.Borrado);
            
            estadohabitacion.Descripcion = Entity.Descripcion;
            estadohabitacion.UsuarioActualizacion = Entity.UsuarioActualizacion;
            estadohabitacion.FechaActualizacion = DateTime.Now;
            
            _dbSet.Update(estadohabitacion);
            await _context.SaveChangesAsync();
        }
    }
}
