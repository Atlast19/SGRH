


using SGRH.Application.DTOs.Habitacion.EstadoHabitacionDto;

namespace SGRH.Application.Interfaces.habitacion
{
    public interface IEstadoHabitacionService
    {
        Task<IEnumerable<ReadEstadoHabitacionDto>> GetAllAsync();
        Task<ReadEstadoHabitacionDto> GetByIdAsync(int Id);
        Task<CreateEstadoHabitacionDto> CreateAsync(CreateEstadoHabitacionDto modelo);
        Task<DeleteEstadoHabitacionDto> DeleteAsync(int Id, int IdUsuario);
        Task<UpdateEstadoHabitacionDto> UpdateAsync(UpdateEstadoHabitacionDto modelo);
    }
}
