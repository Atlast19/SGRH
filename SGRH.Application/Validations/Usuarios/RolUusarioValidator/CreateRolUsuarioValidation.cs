using FluentValidation;
using SGRH.Application.DTOs.Usuarios.RolUsuarioDto;

namespace SGRH.Application.Validations.Usuarios.RolUusarioValidator
{
    public class CreateRolUsuarioValidation : AbstractValidator<CreateRolUsuarioDto>
    {

        public CreateRolUsuarioValidation()
        {

            RuleFor(x => x.Descripcion)
                .NotEmpty()
                .MaximumLength(30)
                .Matches(@"^[\p{L}\s]+$");

            RuleFor(x => x.UsuarioCreacion)
                .NotEmpty()
                .NotEqual(0);
        }

    }
}