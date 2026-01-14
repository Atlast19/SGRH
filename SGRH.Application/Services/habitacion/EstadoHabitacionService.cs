
using SGRH.Application.DTOs.Habitacion;
using SGRH.Application.Interfaces.habitacion;
using SGRH.Domein.Base;
using SGRH.Domein.Interfaces.Habitaciones;

namespace SGRH.Application.Services.habitacion
{
    public class EstadoHabitacionService : IEstadoHabitacionService
    {
        private readonly IEstadoHabitacionRepository _repository;

        public EstadoHabitacionService(IEstadoHabitacionRepository repository)
        {
            _repository = repository;
        }

        public Task<OperationResult<EstadoHabitacionDTO>> CreateAsync(EstadoHabitacionDTO modelo)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<EstadoHabitacionDTO>> DeleteAsync(int Id, int IdUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<IEnumerable<EstadoHabitacionDTO>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<EstadoHabitacionDTO>> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<EstadoHabitacionDTO>> UpdateAsync(EstadoHabitacionDTO modelo)
        {
            throw new NotImplementedException();
        }
    }
}
