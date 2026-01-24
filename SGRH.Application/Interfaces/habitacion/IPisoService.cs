

using SGRH.Application.DTOs.Habitacion.PisoDto;

namespace SGRH.Application.Interfaces.habitacion
{
    public interface IPisoService
    {
        Task<IEnumerable<ReadPisoDto>> GetAllAsync();
        Task<ReadPisoDto> GetByIdAsync(int Id);
        Task<CreatePisoDto> CreateAsync(CreatePisoDto modelo);
        Task<DeletePisoDto> DeleteAsync(int Id, int IdUsuario);
        Task<UpdatePisoDto> UpdateAsync(UpdatePisoDto modelo);
    }
}
