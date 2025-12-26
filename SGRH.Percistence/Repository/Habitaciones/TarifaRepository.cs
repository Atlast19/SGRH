

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGRH.Domein.Base;
using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Habitaciones;
using SGRH.Domein.Models.Habitaciones;
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
        public Task<OperationResult<TarifaModel>> CreateAsync(TarifaModel modelo)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<TarifaModel>> DeleteAsync(int Id, int IdUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<IEnumerable<TarifaModel>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<TarifaModel>> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<TarifaModel>> UpdateAsync(TarifaModel modelo)
        {
            throw new NotImplementedException();
        }
    }
}
