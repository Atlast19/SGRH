using FluentValidation;
using SGRH.Application.DTOs.Usuarios.RolUsuarioDto;

namespace SGRH.Application.Validations.Usuarios.RolUusarioValidator
{
    public class UpdateRolUsuarioValidation : AbstractValidator<UpdateRolUsuarioDto>
    {

        public UpdateRolUsuarioValidation()
        {

            RuleFor(x => x.Descripcion)
                .NotEmpty()
                .MaximumLength(30)
                .Matches(@"^[\p{L}\s]+$");

            RuleFor(x => x.UsuarioActualizacion)
                .NotEmpty()
                .NotEqual(0);
            
        }
    }
}
