
using SGRH.Application.DTOs.Habitacion.HabitacionDto;

namespace SGRH.Application.Interfaces.habitacion
{
    public interface IHabitacionService
    {
        Task<IEnumerable<ReadHabitacionDto>> GetAllAsync();
        Task<ReadHabitacionDto> GetByIdAsync(int Id);
        Task<CreateHabitacionDto> CreateAsync(CreateHabitacionDto modelo);
        Task<DeleteHabitacionDto> DeleteAsync(int Id, int IdUsuario);
        Task<UpdateHabitacionDto> UpdateAsync(UpdateHabitacionDto modelo);
    }
}
