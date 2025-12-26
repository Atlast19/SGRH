
using SGRH.Domein.Entitys.BaseEntitys;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGRH.Domein.Entitys;

[Table("RolUsuario",Schema = "usuario")]
public sealed class RolUsuario : BaseEntity
{
    [Key]
    public int IdRolUsuario { get; set; }

    public string Descripcion { get; set; }

}