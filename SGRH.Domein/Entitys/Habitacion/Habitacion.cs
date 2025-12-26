
using SGRH.Domein.Entitys.BaseEntitys;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGRH.Domein.Entitys;

[Table("Habitacion", Schema = "habitacion")]
public sealed class Habitacion : BaseEntity
{
    [Key]
    public int IdHabitacion { get; set; }

    public string Numero { get; set; }

    public string Detalle { get; set; }

    public decimal Precio { get; set; }

    public int IdEstadoHabitacion { get; set; }

    public int IdPiso { get; set; }

    public int IdCategoria { get; set; }

}