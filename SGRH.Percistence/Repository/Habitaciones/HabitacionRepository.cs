
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGRH.Domein.Base;
using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Habitaciones;
using SGRH.Domein.Models.Habitaciones;
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
        public Task<OperationResult<HbitacionModel>> CreateAsync(HbitacionModel modelo)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<HbitacionModel>> DeleteAsync(int Id, int IdUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<IEnumerable<HbitacionModel>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<HbitacionModel>> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<HbitacionModel>> UpdateAsync(HbitacionModel modelo)
        {
            throw new NotImplementedException();
        }
    }
}
