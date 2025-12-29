

using SGRH.Application.Interfaces.Services;
using SGRH.Domein.Base;
using SGRH.Domein.Interfaces.Servicios;
using SGRH.Domein.Models.Servicios;

namespace SGRH.Application.Services.Servicios
{
    public class ServicioService : IServicioService
    {
        private readonly IServicioRepository _repository;

        public ServicioService(IServicioRepository repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult<ServicioModel>> CreateAsync(ServicioModel modelo)
        {
            return await _repository.CreateAsync(modelo);
        }

        public async Task<OperationResult<ServicioModel>> DeleteAsync(int Id, int IdUsuario)
        {
            return await _repository.DeleteAsync(Id, IdUsuario);
        }

        public async Task<OperationResult<IEnumerable<ServicioModel>>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<OperationResult<ServicioModel>> GetByIdAsync(int Id)
        {
            return await _repository.GetByIdAsync(Id);
        }

        public async Task<OperationResult<ServicioModel>> UpdateAsync(ServicioModel modelo)
        {
            return await _repository.UpdateAsync(modelo);
        }
    }
}
