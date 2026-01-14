

using SGRH.Application.DTOs.Usuarios;
using SGRH.Application.Interfaces.Usuarios;
using SGRH.Domein.Base;
using SGRH.Domein.Interfaces.Usuarios;

namespace SGRH.Application.Services.Usuarios
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public Task<OperationResult<ClienteDTO>> CreateAsync(ClienteDTO modelo)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ClienteDTO>> DeleteAsync(int Id, int IdUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<IEnumerable<ClienteDTO>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ClienteDTO>> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ClienteDTO>> UpdateAsync(ClienteDTO modelo)
        {
            throw new NotImplementedException();
        }
    }
}
