



using SGRH.Application.DTOs.Habitacion.TarifaDto;

namespace SGRH.Application.Interfaces.habitacion
{
    public interface ITarifaService
    {
        Task<IEnumerable<ReadTarifaDto>> GetAllAsync();
        Task<ReadTarifaDto> GetByIdAsync(int Id);
        Task<CreateTarifaDto> CreateAsync(CreateTarifaDto modelo);
        Task<DeleteTarifaDto> DeleteAsync(int Id, int IdUsuario);
        Task<UpdateTarifaDto> UpdateAsync(UpdateTarifaDto modelo);
    }
}
