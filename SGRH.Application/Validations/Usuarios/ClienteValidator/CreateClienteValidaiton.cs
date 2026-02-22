using FluentValidation;
using SGRH.Application.DTOs.Usuarios.ClienteDto;
using System.Reflection.Metadata;

namespace SGRH.Application.Validations.Usuarios.ClienteValidator
{
    public class CreateClienteValidaiton : AbstractValidator<CreateClienteDto>
    {
        public CreateClienteValidaiton()
        {
            RuleFor(x => x.NombreCompleto)
                .NotEmpty()
                .Matches(@"^[\p{L}\s]+$")
                .MaximumLength(50);

            RuleFor(x => x.TipoDocumento)
                .NotEmpty()
                .Matches(@"^[\p{L}\s]+$")
                .MaximumLength(15);

            RuleFor(x => x.Documento)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(15);

            RuleFor(x => x.Correo)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.UsuarioCreacion)
                .GreaterThan(0);
        }
    }
}
