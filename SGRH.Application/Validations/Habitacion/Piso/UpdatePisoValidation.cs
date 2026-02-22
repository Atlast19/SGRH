using FluentValidation;
using SGRH.Application.DTOs.Habitacion.PisoDto;

namespace SGRH.Application.Validations.Habitacion.Piso
{
    public class UpdatePisoValidation : AbstractValidator<UpdatePisoDto>
    {
        public UpdatePisoValidation()
        {
            RuleFor(x => x.Descripcion)
                .NotEmpty()
                .Matches(@"^[\p{L}\s]+$")
                .MaximumLength(50);

            RuleFor(x => x.UsuarioActualizacion)                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
