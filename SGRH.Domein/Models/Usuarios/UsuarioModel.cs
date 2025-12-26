

using SGRH.Domein.Models.Base;

namespace SGRH.Domein.Models.Usuarios
{
    public class UsuarioModel : BaseModel
    {
        public int IdUsuario { get; set; }

        public string NombreCompleto { get; set; }

        public string Correo { get; set; }

        public int IdRolUsuario { get; set; }

        public string Clave { get; set; }
    }
}
