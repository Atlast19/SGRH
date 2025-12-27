
using SGRH.Application.Interfaces.Usuarios;
using SGRH.Domein.Base;
using SGRH.Domein.Interfaces.Usuarios;
using SGRH.Domein.Models.Usuarios;

namespace SGRH.Application.Services.Usuarios
{
    public class RolUsuarioService : IRolUsuarioService
    {
        private readonly IRolUsuarioRepository _repository;

        public RolUsuarioService(IRolUsuarioRepository repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult<RolUsuarioModel>> CreateAsync(RolUsuarioModel modelo)
        {
            return await _repository.CreateAsync(modelo);
        }

        public async Task<OperationResult<RolUsuarioModel>> DeleteAsync(int Id, int IdUsuario)
        {
            return await _repository.DeleteAsync(Id, IdUsuario);
        }

        public async Task<OperationResult<IEnumerable<RolUsuarioModel>>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<OperationResult<RolUsuarioModel>> GetByIdAsync(int Id)
        {
            return await _repository.GetByIdAsync(Id);
        }

        public async Task<OperationResult<RolUsuarioModel>> UpdateAsync(RolUsuarioModel modelo)
        {
            return await _repository.UpdateAsync(modelo);
        }
    }
}
