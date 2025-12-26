
using SGRH.Domein.Entitys.BaseEntitys;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGRH.Domein.Entitys;

[Table("Usuario",Schema = "usuario")]
public sealed class Usuario : BaseEntity
{
    [Key]
    public int IdUsuario { get; set; }

    public string NombreCompleto { get; set; }

    public string Correo { get; set; }

    public int IdRolUsuario { get; set; }

    public string Clave { get; set; }


}