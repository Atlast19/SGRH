
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Servicios;
using SGRH.Percistence.Context;

namespace SGRH.Percistence.Repository.Servicios
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly SGHRContext _context;
        private readonly ILogger<ReservaRepository> _logger;
        DbSet<Reserva> _dbSet;
        public ReservaRepository(SGHRContext context, ILogger<ReservaRepository> logger)
        {
            _context = context;
            _logger = logger;
            _dbSet = context.Set<Reserva>();
        }
        public async Task CreateAsync(Reserva Entity)
        {

            _logger.LogInformation("Proceso para crear una reserva");
            
            await _dbSet.AddAsync(Entity);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int Id, int IdUsuario)
        {

            _logger.LogInformation("Procesa para eliminar una reserva");

            var reserva = await _dbSet.FirstOrDefaultAsync(c => c.IdReserva == Id && !c.Borrado);

            reserva.Estado = false;
            reserva.Borrado = true;
            reserva.FechaEliminado = DateTime.Now;
            reserva.UsuarioEliminacion = IdUsuario;

            _dbSet.Update(reserva);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Reserva>> GetAllAsync()
        {

            _logger.LogInformation("Proceso para cargar todos los datos de la reserva");
            
            return await _dbSet.ToListAsync();
        }

        public async Task<Reserva?> GetByIdAsync(int Id)
        {

            _logger.LogInformation("Proceso para cargar la reserva por ID");

            return await _dbSet.FirstOrDefaultAsync(c => c.IdReserva == Id && !c.Borrado);
        }

        public async Task UpdateAsync(Reserva Entity)
        {

            _logger.LogInformation("Proceso para actualizar una reserva");
            
            var reserva = await _dbSet.FirstOrDefaultAsync(c => c.IdReserva == Entity.IdReserva && !c.Borrado);

                    reserva.IdCliente = Entity.IdCliente;
                    reserva.IdHabitacion = Entity.IdHabitacion;
                    reserva.FechaEntrada = Entity.FechaEntrada;
                    reserva.FechaSalida = Entity.FechaSalida;
                    reserva.FechaSalidaConfirmacion = Entity.FechaSalidaConfirmacion;
                    reserva.PrecioInicial = Entity.PrecioInicial;
                    reserva.Adelanto = Entity.Adelanto;
                    reserva.PrecioRestante = Entity.PrecioRestante;
                    reserva.TotalPagado = Entity.TotalPagado;
                    reserva.CostoPenalidad = Entity.CostoPenalidad;
                    reserva.Observacion = Entity.Observacion;

                    reserva.UsuarioActualizacion = Entity.UsuarioActualizacion;
                    reserva.FechaActualizacion = DateTime.Now;

                _dbSet.Update(reserva);
                await _context.SaveChangesAsync();

        }
    }
}
