using FluentValidation;
using SGRH.Application.DTOs.Habitacion.EstadoHabitacionDto;

namespace SGRH.Application.Validations.Habitacion.EstadoHabitacion
{
    public class UpdateEstadoHabitacionValidation : AbstractValidator<UpdateEstadoHabitacionDto>
    {
        public UpdateEstadoHabitacionValidation()
        {
            RuleFor(x => x.Descripcion)
                .NotEmpty()
                .Matches(@"^[\p{L}\s]+$")
                .MaximumLength(50);

            RuleFor(x => x.UsuarioActualizacion)
                .GreaterThan(0);
        }
    }
}
