

using SGRH.Domein.Models.Base;

namespace SGRH.Domein.Models.Usuarios
{
    public class RolUsuarioModel : BaseModel
    {
        public int IdRolUsuario { get; set; }

        public string Descripcion { get; set; }
    }
}
