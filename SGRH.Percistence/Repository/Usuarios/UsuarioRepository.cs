

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGRH.Domein.Base;
using SGRH.Domein.Interfaces.Usuarios;
using SGRH.Domein.Models.Usuarios;
using SGRH.Percistence.Context;

namespace SGRH.Percistence.Repository.Usuarios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SGHRContext _context;
        private readonly ILogger<UsuarioRepository> _logger;
        DbSet<Domein.Entitys.Usuario> _dbSet;
        public UsuarioRepository(SGHRContext context, ILogger<UsuarioRepository> logger)
        {
            _context = context;
            _logger = logger;
            _dbSet = context.Set<SGRH.Domein.Entitys.Usuario>();
        }

        public Task<OperationResult<UsuarioModel>> CreateAsync(UsuarioModel modelo)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<UsuarioModel>> DeleteAsync(int Id, int IdUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<IEnumerable<UsuarioModel>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<UsuarioModel>> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<UsuarioModel>> UpdateAsync(UsuarioModel modelo)
        {
            throw new NotImplementedException();
        }
    }
}
