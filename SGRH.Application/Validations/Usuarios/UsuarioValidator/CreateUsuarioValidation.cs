

using FluentValidation;
using SGRH.Application.DTOs.Usuarios.UsuarioDto;

namespace SGRH.Application.Validations.Usuarios.UsuarioValidator
{
    public class CreateUsuarioValidation : AbstractValidator<CreateUsuarioDto>
    {
        public CreateUsuarioValidation()
        {
            RuleFor(x => x.NombreCompleto)
                .NotEmpty()
                .MaximumLength(50)
                .Matches(@"^[\p{L}\s]+$");

            RuleFor(x => x.Correo)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.IdRolUsuario)
                .GreaterThan(0);

            RuleFor(x => x.Clave)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.UsuarioCreacion)
                .GreaterThan(0);
        }
    }
}
