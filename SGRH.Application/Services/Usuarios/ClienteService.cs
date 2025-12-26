

using SGRH.Application.Interfaces.Usuarios;
using SGRH.Domein.Base;
using SGRH.Domein.Interfaces.Usuarios;
using SGRH.Domein.Models.Usuarios;

namespace SGRH.Application.Services.Usuarios
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public Task<OperationResult<ClienteModel>> CreateAsync(ClienteModel modelo)
        {
            return _repository.CreateAsync(modelo);
        }

        public Task<OperationResult<ClienteModel>> DeleteAsync(int Id, int IdUsuario)
        {
            return _repository.DeleteAsync(Id, IdUsuario);
        }

        public Task<OperationResult<IEnumerable<ClienteModel>>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<OperationResult<ClienteModel>> GetByIdAsync(int Id)
        {
            return _repository.GetByIdAsync(Id);
        }

        public Task<OperationResult<ClienteModel>> UpdateAsync(ClienteModel modelo)
        {
            return _repository.UpdateAsync(modelo);
        }
    }
}
