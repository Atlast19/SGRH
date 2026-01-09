
using SGRH.Application.Interfaces.habitacion;
using SGRH.Domein.Base;
using SGRH.Domein.Interfaces.Habitaciones;
using SGRH.Domein.Models.Habitaciones;

namespace SGRH.Application.Services.habitacion
{
    public class EstadoHabitacionService : IEstadoHabitacionService
    {
        private readonly IEstadoHabitacionRepository _repository;

        public EstadoHabitacionService(IEstadoHabitacionRepository repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult<EstadoHabitacionModel>> CreateAsync(EstadoHabitacionModel modelo)
        {
            return await _repository.CreateAsync(modelo);
        }

        public async Task<OperationResult<EstadoHabitacionModel>> DeleteAsync(int Id, int IdUsuario)
        {
            return await _repository.DeleteAsync(Id, IdUsuario);
        }

        public async Task<OperationResult<IEnumerable<EstadoHabitacionModel>>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<OperationResult<EstadoHabitacionModel>> GetByIdAsync(int Id)
        {
            return await _repository.GetByIdAsync(Id);
        }

        public async Task<OperationResult<EstadoHabitacionModel>> UpdateAsync(EstadoHabitacionModel modelo)
        {
            return await _repository.UpdateAsync(modelo);
        }
    }
}
