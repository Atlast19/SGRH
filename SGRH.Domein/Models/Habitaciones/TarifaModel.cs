
using SGRH.Domein.Models.Base;

namespace SGRH.Domein.Models.Habitaciones
{
    public class TarifaModel : BaseModel
    {
        public int IdTarifa { get; set; }
        
        public int IdHabitacion { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin { get; set; }
        public decimal PrecioPorNoche { get; set; }
        public decimal Descuento { get; set; }
        public string Descripcion { get; set; }

    }
}
