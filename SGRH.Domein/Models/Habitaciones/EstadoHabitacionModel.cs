

using SGRH.Domein.Models.Base;

namespace SGRH.Domein.Models.Habitaciones
{
    public class EstadoHabitacionModel : BaseModel
    {
        public int IdEstadoHabitacion { get; set; }

        public string Descripcion { get; set; }
    }
}
