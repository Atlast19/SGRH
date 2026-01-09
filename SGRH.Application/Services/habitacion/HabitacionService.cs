
using SGRH.Application.Interfaces.habitacion;
using SGRH.Domein.Base;
using SGRH.Domein.Interfaces.Habitaciones;
using SGRH.Domein.Models.Habitaciones;

namespace SGRH.Application.Services.habitacion
{
    public class HabitacionService : IHabitacionService
    {
        private readonly IHabitacionRepository _repository;

        public HabitacionService(IHabitacionRepository repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult<HabitacionModel>> CreateAsync(HabitacionModel modelo)
        {
            return await _repository.CreateAsync(modelo);
        }

        public async Task<OperationResult<HabitacionModel>> DeleteAsync(int Id, int IdUsuario)
        {
            return await _repository.DeleteAsync(Id,IdUsuario);
        }

        public async Task<OperationResult<IEnumerable<HabitacionModel>>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<OperationResult<HabitacionModel>> GetByIdAsync(int Id)
        {
            return await _repository.GetByIdAsync(Id);
        }

        public async Task<OperationResult<HabitacionModel>> UpdateAsync(HabitacionModel modelo)
        {
            return await _repository.UpdateAsync(modelo);
        }
    }
}
