
using SGRH.Application.DTOs.Usuarios.UsuarioDto;

namespace SGRH.Application.Interfaces.Usuarios
{
    public interface IUsuarioService
    {
        Task<IEnumerable<ReadUsuarioDto>> GetAllAsync();
        Task<ReadUsuarioDto> GetByIdAsync(int Id);
        Task<CreateUsuarioDto> CreateAsync(CreateUsuarioDto modelo);
        Task<DeleteUsuarioDto> DeleteAsync(int Id, int IdUsuario);
        Task<UpdateUsuarioDto> UpdateAsync(UpdateUsuarioDto modelo);
    }
}