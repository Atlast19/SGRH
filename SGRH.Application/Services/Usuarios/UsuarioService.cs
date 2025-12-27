

using SGRH.Application.Interfaces.Usuarios;
using SGRH.Domein.Base;
using SGRH.Domein.Interfaces.Usuarios;
using SGRH.Domein.Models.Usuarios;

namespace SGRH.Application.Services.Usuarios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult<UsuarioModel>> CreateAsync(UsuarioModel modelo)
        {
            return await _repository.CreateAsync(modelo);
        }

        public async Task<OperationResult<UsuarioModel>> DeleteAsync(int Id, int IdUsuario)
        {
            return await _repository.DeleteAsync(Id, IdUsuario);
        }

        public async Task<OperationResult<IEnumerable<UsuarioModel>>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<OperationResult<UsuarioModel>> GetByIdAsync(int Id)
        {
            return await _repository.GetByIdAsync(Id);
        }

        public async Task<OperationResult<UsuarioModel>> UpdateAsync(UsuarioModel modelo)
        {
            return await _repository.UpdateAsync(modelo);
        }
    }
}
