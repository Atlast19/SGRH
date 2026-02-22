using FluentValidation;
using SGRH.Application.DTOs.Habitacion.EstadoHabitacionDto;

namespace SGRH.Application.Validations.Habitacion.EstadoHabitacion
{
    public class CreateEstadoHabitacionValidation : AbstractValidator<CreateEstadoHabitacionDto>
    {
        public CreateEstadoHabitacionValidation()
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
