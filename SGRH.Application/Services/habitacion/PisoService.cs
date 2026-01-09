

using SGRH.Application.Interfaces.habitacion;
using SGRH.Domein.Base;
using SGRH.Domein.Interfaces.Habitaciones;
using SGRH.Domein.Models.Habitaciones;

namespace SGRH.Application.Services.habitacion
{
    public class PisoService : IPisoService
    {
        private readonly IPisoRepository _respository;

        public PisoService(IPisoRepository respository)
        {
            _respository = respository;
        }
        public async Task<OperationResult<PisoModel>> CreateAsync(PisoModel modelo)
        {
            return await _respository.CreateAsync(modelo);
        }

        public async Task<OperationResult<PisoModel>> DeleteAsync(int Id, int IdUsuario)
        {
            return await _respository.DeleteAsync(Id,IdUsuario);
        }

        public async Task<OperationResult<IEnumerable<PisoModel>>> GetAllAsync()
        {
            return await _respository.GetAllAsync();
        }

        public async Task<OperationResult<PisoModel>> GetByIdAsync(int Id)
        {
            return await _respository.GetByIdAsync(Id);
        }

        public async Task<OperationResult<PisoModel>> UpdateAsync(PisoModel modelo)
        {
            return await _respository.UpdateAsync(modelo);
        }
    }
}
