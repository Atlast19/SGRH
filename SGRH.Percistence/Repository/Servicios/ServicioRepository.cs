
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGRH.Domein.Base;
using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Servicios;
using SGRH.Domein.Models.Servicios;
using SGRH.Percistence.Context;

namespace SGRH.Percistence.Repository.Servicios
{
    public class ServicioRepository : IServicioRepository
    {
        private readonly SGHRContext _context;
        private readonly ILogger<ServicioRepository> _logger;
        DbSet<Servicio> _dbSet;
        public ServicioRepository(SGHRContext context, ILogger<ServicioRepository> logger)
        {
            _context = context;
            _logger = logger;
            _dbSet = context.Set<Servicio>();
        }
        public Task<OperationResult<ServicioModel>> CreateAsync(ServicioModel modelo)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ServicioModel>> DeleteAsync(int Id, int IdUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<IEnumerable<ServicioModel>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ServicioModel>> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ServicioModel>> UpdateAsync(ServicioModel modelo)
        {
            throw new NotImplementedException();
        }
    }
}
