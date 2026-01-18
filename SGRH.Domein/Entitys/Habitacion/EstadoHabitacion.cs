using SGRH.Domein.Entitys.BaseEntitys;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGRH.Domein.Entitys;

[Table("EstadoHabitacion",Schema = "habitacion")]
public sealed class EstadoHabitacion : BaseEntity
{
    [Key]
    public int IdEstadoHabitacion { get; set; }

    public string Descripcion { get; set; }

}