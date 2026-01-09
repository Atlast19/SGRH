
using SGRH.Domein.Models.Base;

namespace SGRH.Domein.Models.Habitaciones
{
    public class CategoriumModel : BaseModel
    {
        public int IdCategoria { get; set; }

        public string Descripcion { get; set; }

        public int IdServicio { get; set; }
    }
}
