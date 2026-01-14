
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGRH.Domein.Base;
using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Habitaciones;

using SGRH.Percistence.Context;


namespace SGRH.Percistence.Repository.Habitaciones
{
    public class HabitacionRepository : IHabitacionRepository
    {
        private readonly SGHRContext _context;
        private readonly ILogger<HabitacionRepository> _logger;
        DbSet<Habitacion> _dbSet;
        public HabitacionRepository(SGHRContext context, ILogger<HabitacionRepository> logger)
        {
            _context = context;
            _logger = logger;
            _dbSet = context.Set<Habitacion>();
        }
        public async Task CreateAsync(Habitacion Entity)
        {
            _logger.LogInformation("Proceso para crear una habitacion");

            await _dbSet.AddAsync(Entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id, int IdUsuario)
        {

            _logger.LogInformation("Proceso para eliminar los datos");

                var habitacion = await _dbSet.FirstOrDefaultAsync(c => c.IdHabitacion == Id && !c.Borrado);


                habitacion.Borrado = true;
                habitacion.Estado = false;
                habitacion.UsuarioEliminacion = IdUsuario;
                habitacion.FechaEliminado = DateTime.Now;

                _dbSet.Update(habitacion);
                await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Habitacion>> GetAllAsync()
        {

            _logger.LogInformation("Proceso para mostrar las habitaciones");
            
            return await _dbSet.ToListAsync();
        }

        public async Task<Habitacion?> GetByIdAsync(int Id)
        {

            _logger.LogInformation("Cargando los datos por ID");
            
            return await _dbSet.FirstOrDefaultAsync(c => c.IdHabitacion == Id && !c.Borrado);

        }

        public async Task UpdateAsync(Habitacion Entiry)
        {


            _logger.LogInformation("Proceso para actualizar una habitacion");
            
            var habitacion = await _dbSet.FirstOrDefaultAsync(c => c.IdHabitacion == Entiry.IdHabitacion && !c.Borrado);

            habitacion.Numero = Entiry.Numero;
            habitacion.Detalle = Entiry.Detalle;
            habitacion.Precio = Entiry.Precio;
            habitacion.IdEstadoHabitacion = Entiry.IdEstadoHabitacion;
            habitacion.IdPiso = Entiry.IdPiso;
            habitacion.IdCategoria = Entiry.IdCategoria;

            habitacion.UsuarioActualizacion = Entiry.UsuarioActualizacion;
            habitacion.FechaActualizacion = DateTime.Now;

            _dbSet.Update(habitacion);
            await _context.SaveChangesAsync();
        }
    }
}
