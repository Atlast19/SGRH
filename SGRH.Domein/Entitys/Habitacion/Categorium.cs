
using SGRH.Domein.Entitys.BaseEntitys;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGRH.Domein.Entitys;

[Table("Categoria",Schema = "habitacion")]
public sealed class Categorium : BaseEntity
{
    [Key]
    public int IdCategoria { get; set; }

    public string Descripcion { get; set; }

    public int IdServicio { get; set; }



}