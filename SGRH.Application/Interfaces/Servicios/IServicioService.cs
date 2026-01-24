

using SGRH.Application.DTOs.Reserva.ServicioDto;

namespace SGRH.Application.Interfaces.Services
{
    public interface IServicioService
    {
        Task<IEnumerable<ReadServicioDto>> GetAllAsync();
        Task<ReadServicioDto> GetByIdAsync(int Id);
        Task<CreateServicioDto> CreateAsync(CreateServicioDto modelo);
        Task<DeleteServicioDto> DeleteAsync(int Id, int IdUsuario);
        Task<UpdateServicioDto> UpdateAsync(UpdateServicioDto modelo);
    }
}
