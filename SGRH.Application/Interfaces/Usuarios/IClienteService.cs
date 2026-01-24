using SGRH.Application.DTOs.Usuarios.ClienteDto;

namespace SGRH.Application.Interfaces.Usuarios
{
    public interface IClienteService
    {
        Task<IEnumerable<ReadClienteDto>> GetAllAsync();
        Task<ReadClienteDto> GetByIdAsync(int Id);
        Task<CreateClienteDto> CreateAsync(CreateClienteDto modelo);
        Task<DeleteClienteDto> DeleteAsync(int Id, int IdUsuario);
        Task<UpdateClienteDto> UpdateAsync(UpdateClienteDto modelo);
    }
}
