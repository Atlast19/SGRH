

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
                .MaximumLength(35)
                .Matches(@"^[\p{L}\s]+$");

            RuleFor(x => x.Correo)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.IdRolUsuario)
                .NotEmpty()
                .NotEqual(0);

            RuleFor(x => x.Clave)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(x => x.UsuarioCreacion)
                .NotEmpty()
                .NotEqual(0);
        }
    }
}
