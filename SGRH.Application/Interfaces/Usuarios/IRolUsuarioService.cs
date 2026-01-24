
using SGRH.Application.DTOs.Usuarios.RolUsuarioDto;


namespace SGRH.Application.Interfaces.Usuarios
{
    public interface IRolUsuarioService
    {
        Task<IEnumerable<ReadRolUsuarioDto>> GetAllAsync();
        Task<ReadRolUsuarioDto> GetByIdAsync(int Id);
        Task<CreateRolUsuarioDto> CreateAsync(CreateRolUsuarioDto modelo);
        Task<DeleteRolUsuarioDto> DeleteAsync(int Id, int IdUsuario);
        Task<UpdateRolUsuarioDto> UpdateAsync(UpdateRolUsuarioDto modelo);
    }
}
