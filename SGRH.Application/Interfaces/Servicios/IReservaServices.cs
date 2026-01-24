
using SGRH.Application.DTOs.Reserva.ReservaDto;

namespace SGRH.Application.Interfaces.Services
{
    public interface IReservaServices
    {
        Task<IEnumerable<ReadReservaDto>> GetAllAsync();
        Task<ReadReservaDto> GetByIdAsync(int Id);
        Task<CreateReservaDto> CreateAsync(CreateReservaDto modelo);
        Task<DeleteReservaDto> DeleteAsync(int Id, int IdUsuario);
        Task<UpdateReservaDto> UpdateAsync(UpdateReservaDto modelo);
    }
}
