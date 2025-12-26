

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGRH.Domein.Base;
using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Usuarios;
using SGRH.Domein.Models.Usuarios;
using SGRH.Percistence.Context;

namespace SGRH.Percistence.Repository.Usuarios
{
    public class RolUsuarioRepository : IRolUsuarioRepository
    {
        private readonly SGHRContext _context;
        private readonly ILogger<RolUsuarioRepository> _logger;
        DbSet<RolUsuario> _dbSet;

        public RolUsuarioRepository(SGHRContext context, ILogger<RolUsuarioRepository> logger)
        {
            _context = context;
            _logger = logger;
            _dbSet = context.Set<RolUsuario>();
        }

        public Task<OperationResult<RolUsuarioModel>> CreateAsync(RolUsuarioModel modelo)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<RolUsuarioModel>> DeleteAsync(int Id, int IdUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<IEnumerable<RolUsuarioModel>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<RolUsuarioModel>> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<RolUsuarioModel>> UpdateAsync(RolUsuarioModel modelo)
        {
            throw new NotImplementedException();
        }
    }
}
