
using SGRH.Application.DTOs.Usuarios;
using SGRH.Application.Interfaces.Usuarios;
using SGRH.Domein.Base;
using SGRH.Domein.Interfaces.Usuarios;

namespace SGRH.Application.Services.Usuarios
{
    public class RolUsuarioService : IRolUsuarioService
    {
        private readonly IRolUsuarioRepository _repository;

        public RolUsuarioService(IRolUsuarioRepository repository)
        {
            _repository = repository;
        }

        public Task<OperationResult<RolUsuarioDTO>> CreateAsync(RolUsuarioDTO modelo)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<RolUsuarioDTO>> DeleteAsync(int Id, int IdUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<IEnumerable<RolUsuarioDTO>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<RolUsuarioDTO>> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<RolUsuarioDTO>> UpdateAsync(RolUsuarioDTO modelo)
        {
            throw new NotImplementedException();
        }
    }
}
