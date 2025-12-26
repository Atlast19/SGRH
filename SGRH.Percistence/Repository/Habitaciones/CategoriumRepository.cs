
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGRH.Domein.Base;
using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Habitaciones;
using SGRH.Domein.Models.Habitaciones;
using SGRH.Percistence.Context;

namespace SGRH.Percistence.Repository.Habitaciones
{
    public class CategoriumRepository : ICategoriumRepository
    {
        private readonly SGHRContext _context;
        private readonly ILogger<CategoriumRepository> _logger;
        DbSet<Categorium> _dbSet;
        public CategoriumRepository(SGHRContext context, ILogger<CategoriumRepository> logger)
        {
            _context = context;
            _logger = logger;
            _dbSet = context.Set<Categorium>();
        }
        public Task<OperationResult<CategoriumModel>> CreateAsync(CategoriumModel modelo)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<CategoriumModel>> DeleteAsync(int Id, int IdUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<IEnumerable<CategoriumModel>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<CategoriumModel>> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<CategoriumModel>> UpdateAsync(CategoriumModel modelo)
        {
            throw new NotImplementedException();
        }
    }
}
