

using SGRH.Application.DTOs.Habitacion;
using SGRH.Application.Interfaces.habitacion;
using SGRH.Domein.Base;
using SGRH.Domein.Interfaces.Habitaciones;

namespace SGRH.Application.Services.habitacion
{
    public class TarifaService : ITarifaService
    {
        private readonly ITarifaRepository _repository;

        public TarifaService(ITarifaRepository repository)
        {
            _repository = repository;
        }

        public Task<OperationResult<TarifaDTO>> CreateAsync(TarifaDTO modelo)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<TarifaDTO>> DeleteAsync(int Id, int IdUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<IEnumerable<TarifaDTO>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<TarifaDTO>> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<TarifaDTO>> UpdateAsync(TarifaDTO modelo)
        {
            throw new NotImplementedException();
        }
    }
}
