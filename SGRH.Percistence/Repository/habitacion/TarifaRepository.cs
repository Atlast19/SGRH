
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Habitaciones;
using SGRH.Percistence.Context;


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
        public async Task CreateAsync(Tarifa Entity)
        {

            _logger.LogInformation("Proceso para crear una tarifa");

            await _dbSet.AddAsync(Entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id, int IdUsuario)
        {

            _logger.LogInformation("Proceso para eliminar una tarifa");
            
            var tarifa = await _dbSet.FirstOrDefaultAsync(c => c.IdTarifa == Id && !c.Borrado);
            
            
            tarifa.Estado = false;
            tarifa.Borrado = true;
            tarifa.FechaEliminado = DateTime.Now;
            tarifa.UsuarioEliminacion = IdUsuario;

            _dbSet.Update(tarifa);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Tarifa>> GetAllAsync()
        {

            _logger.LogInformation("Proceso para cargar todas las tarifas");

            return await _dbSet.ToListAsync();

        }

        public async Task<Tarifa?> GetByIdAsync(int Id)
        {
            _logger.LogInformation("Proceso para cargar las tarifas por ID");

            return await _dbSet.FirstOrDefaultAsync(c => c.IdTarifa == Id && !c.Borrado);
        }

        public async Task UpdateAsync(Tarifa Entity)
        {

            _logger.LogInformation("Proceso para actializar ");
            
            var tarifa = await _dbSet.FirstOrDefaultAsync(c => c.IdTarifa == Entity.IdTarifa && !c.Borrado);
            
            tarifa.IdHabitacion = Entity.IdHabitacion;
            tarifa.FechaInicio = Entity.FechaInicio;
            tarifa.FechaFin = Entity.FechaFin;
            tarifa.PrecioPorNoche = Entity.PrecioPorNoche;
            tarifa.Descuento = Entity.Descuento;
            tarifa.Descripcion = Entity.Descripcion;
            tarifa.UsuarioActualizacion = Entity.UsuarioActualizacion;
            tarifa.FechaActualizacion = DateTime.Now;
            
            _dbSet.Update(tarifa);
            await _context.SaveChangesAsync();

        }
    }
}
