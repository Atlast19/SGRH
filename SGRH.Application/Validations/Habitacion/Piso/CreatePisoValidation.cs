using FluentValidation;
using SGRH.Application.DTOs.Habitacion.PisoDto;

namespace SGRH.Application.Validations.Habitacion.Piso
{
    public class CreatePisoValidation : AbstractValidator<CreatePisoDto>
    {
        public CreatePisoValidation()
        {
            RuleFor(x => x.Descripcion)
                .NotEmpty()
                .Matches(@"^[\p{L}\s]+$")
                .MaximumLength(50);

            RuleFor(x => x.UsuarioCreacion)
                .GreaterThan(0);
        }
    }
}
