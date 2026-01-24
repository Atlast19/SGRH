

using SGRH.Application.DTOs.Habitacion.CategoriumDto;

namespace SGRH.Application.Interfaces.habitacion
{
    public interface ICategoriumService
    {
        Task<IEnumerable<ReadCategoriumDto>> GetAllAsync();
        Task<ReadCategoriumDto> GetByIdAsync(int Id);
        Task<CreateCategoriumDto> CreateAsync(CreateCategoriumDto modelo);
        Task<DeleteCategoriumDto> DeleteAsync(int Id, int IdUsuario);
        Task<UpdateCategoriumDto> UpdateAsync(UpdateCategoriumDto modelo);
    }
}
