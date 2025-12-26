
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGRH.Domein.Base;
using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Habitaciones;
using SGRH.Domein.Models.Habitaciones;
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
        public Task<OperationResult<EstadoHabitacionModel>> CreateAsync(EstadoHabitacionModel modelo)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<EstadoHabitacionModel>> DeleteAsync(int Id, int IdUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<IEnumerable<EstadoHabitacionModel>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<EstadoHabitacionModel>> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<EstadoHabitacionModel>> UpdateAsync(EstadoHabitacionModel modelo)
        {
            throw new NotImplementedException();
        }
    }
}
