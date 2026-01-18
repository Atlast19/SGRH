
using SGRH.Application.DTOs.Base;

namespace SGRH.Application.DTOs.Habitacion
{
    public class CategoriumDTO : BaseDTO
    {
        public int IdCategoria { get; set; }

        public string Descripcion { get; set; }

        public int IdServicio { get; set; }
    }
}
