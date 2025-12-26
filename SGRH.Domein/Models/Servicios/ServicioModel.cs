

using SGRH.Domein.Models.Base;

namespace SGRH.Domein.Models.Servicios
{
    public class ServicioModel : BaseModel
    {
        public int IdServicio { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }
    }
}
