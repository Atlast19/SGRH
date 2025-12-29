

using SGRH.Application.Interfaces.Services;
using SGRH.Domein.Base;
using SGRH.Domein.Interfaces.Servicios;
using SGRH.Domein.Models.Servicios;

namespace SGRH.Application.Services.Servicios
{
    public class ReservaService : IReservaServices
    {
        private readonly IReservaRepository _repository;

        public ReservaService(IReservaRepository repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult<ReservaModel>> CreateAsync(ReservaModel modelo)
        {
            return await _repository.CreateAsync(modelo);
        }

        public async Task<OperationResult<ReservaModel>> DeleteAsync(int Id, int IdUsuario)
        {
            return await _repository.DeleteAsync(Id,IdUsuario);
        }

        public async Task<OperationResult<IEnumerable<ReservaModel>>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<OperationResult<ReservaModel>> GetByIdAsync(int Id)
        {
            return await _repository.GetByIdAsync(Id);
        }

        public async Task<OperationResult<ReservaModel>> UpdateAsync(ReservaModel modelo)
        {
            return await _repository.UpdateAsync(modelo);
        }
    }
}
