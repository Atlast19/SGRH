using FluentValidation;
using SGRH.Application.DTOs.Usuarios.ClienteDto;

namespace SGRH.Application.Validations.Usuarios.ClienteValidator
{
    public class UpdateClienteValidation : AbstractValidator<UpdateClienteDto>
    {
        public UpdateClienteValidation()
        {
            RuleFor(x => x.IdCliente)
                .NotEmpty()
                .NotEqual(0);

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
                .MaximumLength(15);

            RuleFor(x => x.Correo)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.UsuarioActualizacion)
                .GreaterThan(0);
        }
    }
}
