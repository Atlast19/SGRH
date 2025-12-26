

using SGRH.Domein.Models.Base;

namespace SGRH.Domein.Models.Usuarios
{
    public class ClienteModel : BaseModel
    {

        public int IdCliente { get; set; }

        public string TipoDocumento { get; set; }

        public string Documento { get; set; }

        public string NombreCompleto { get; set; }

        public string Correo { get; set; }

    }
}
