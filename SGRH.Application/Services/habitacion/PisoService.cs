

using SGRH.Application.DTOs.Habitacion;
using SGRH.Application.Interfaces.habitacion;
using SGRH.Domein.Base;
using SGRH.Domein.Interfaces.Habitaciones;

namespace SGRH.Application.Services.habitacion
{
    public class PisoService : IPisoService
    {
        private readonly IPisoRepository _respository;

        public PisoService(IPisoRepository respository)
        {
            _respository = respository;
        }

        public Task<OperationResult<PisoDTO>> CreateAsync(PisoDTO modelo)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<PisoDTO>> DeleteAsync(int Id, int IdUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<IEnumerable<PisoDTO>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<PisoDTO>> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<PisoDTO>> UpdateAsync(PisoDTO modelo)
        {
            throw new NotImplementedException();
        }
    }
}
