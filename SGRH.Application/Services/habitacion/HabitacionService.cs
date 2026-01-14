
using SGRH.Application.DTOs.Habitacion;
using SGRH.Application.Interfaces.habitacion;
using SGRH.Domein.Base;
using SGRH.Domein.Interfaces.Habitaciones;

namespace SGRH.Application.Services.habitacion
{
    public class HabitacionService : IHabitacionService
    {
        private readonly IHabitacionRepository _repository;

        public HabitacionService(IHabitacionRepository repository)
        {
            _repository = repository;
        }

        public Task<OperationResult<HabitacionDTO>> CreateAsync(HabitacionDTO modelo)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<HabitacionDTO>> DeleteAsync(int Id, int IdUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<IEnumerable<HabitacionDTO>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<HabitacionDTO>> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<HabitacionDTO>> UpdateAsync(HabitacionDTO modelo)
        {
            throw new NotImplementedException();
        }
    }
}
