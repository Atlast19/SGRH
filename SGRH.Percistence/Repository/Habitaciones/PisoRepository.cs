

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGRH.Domein.Base;
using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Habitaciones;
using SGRH.Domein.Models.Habitaciones;
using SGRH.Percistence.Context;

namespace SGRH.Percistence.Repository.Habitaciones
{
    public class PisoRepository : IPisoRepository
    {
        private readonly SGHRContext _context;
        private readonly ILogger<PisoRepository> _logger;
        DbSet<Piso> _dbSet;
        public PisoRepository(SGHRContext context, ILogger<PisoRepository> logger)
        {
            _context = context;
            _logger = logger;
            _dbSet = context.Set<Piso>();
        }

        public Task<OperationResult<PisoModel>> CreateAsync(PisoModel modelo)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<PisoModel>> DeleteAsync(int Id, int IdUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<IEnumerable<PisoModel>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<PisoModel>> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<PisoModel>> UpdateAsync(PisoModel modelo)
        {
            throw new NotImplementedException();
        }
    }
}
