

using SGRH.Application.DTOs.Base;

namespace SGRH.Application.DTOs.Usuarios
{
    public class RolUsuarioDTO : BaseDTO
    {
        public int IdRolUsuario { get; set; }

        public string Descripcion { get; set; }
    }
}
