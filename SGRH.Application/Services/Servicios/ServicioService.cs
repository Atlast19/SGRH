

using SGRH.Application.DTOs.Reserva;
using SGRH.Application.Interfaces.Services;
using SGRH.Domein.Base;
using SGRH.Domein.Interfaces.Servicios;


namespace SGRH.Application.Services.Servicios
{
    public class ServicioService : IServicioService
    {
        private readonly IServicioRepository _repository;

        public ServicioService(IServicioRepository repository)
        {
            _repository = repository;
        }

        public Task<OperationResult<ServicioDTO>> CreateAsync(ServicioDTO modelo)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ServicioDTO>> DeleteAsync(int Id, int IdUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<IEnumerable<ServicioDTO>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ServicioDTO>> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ServicioDTO>> UpdateAsync(ServicioDTO modelo)
        {
            throw new NotImplementedException();
        }
    }
}
