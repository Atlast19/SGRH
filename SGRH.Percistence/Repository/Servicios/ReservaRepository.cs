

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGRH.Domein.Base;
using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Servicios;
using SGRH.Domein.Models.Servicios;
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
        public Task<OperationResult<ReservaModel>> CreateAsync(ReservaModel modelo)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ReservaModel>> DeleteAsync(int Id, int IdUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<IEnumerable<ReservaModel>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ReservaModel>> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ReservaModel>> UpdateAsync(ReservaModel modelo)
        {
            throw new NotImplementedException();
        }
    }
}
