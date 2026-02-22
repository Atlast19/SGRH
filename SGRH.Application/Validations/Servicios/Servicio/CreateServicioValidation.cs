using FluentValidation;
using SGRH.Application.DTOs.Reserva.ServicioDto;

namespace SGRH.Application.Validations.Servicios.Servicio
{
    public class CreateServicioValidation : AbstractValidator<CreateServicioDto>
    {
        public CreateServicioValidation()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty()
                .Matches(@"^[\p{L}\s]+$")
                .MaximumLength(50);

            RuleFor(x => x.Descripcion)
                .NotEmpty()
                .Matches(@"^[\p{L}\s]+$")
                .MaximumLength(500);

            RuleFor(x => x.UsuarioCreacion)
                .GreaterThan(0);
        }
    }
}
