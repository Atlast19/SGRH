

using SGRH.Application.DTOs.Reserva;
using SGRH.Application.Interfaces.Services;
using SGRH.Domein.Base;
using SGRH.Domein.Interfaces.Servicios;

namespace SGRH.Application.Services.Servicios
{
    public class ReservaService : IReservaServices
    {
        private readonly IReservaRepository _repository;

        public ReservaService(IReservaRepository repository)
        {
            _repository = repository;
        }

        public Task<OperationResult<ReservaDTO>> CreateAsync(ReservaDTO modelo)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ReservaDTO>> DeleteAsync(int Id, int IdUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<IEnumerable<ReservaDTO>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ReservaDTO>> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ReservaDTO>> UpdateAsync(ReservaDTO modelo)
        {
            throw new NotImplementedException();
        }
    }
}
