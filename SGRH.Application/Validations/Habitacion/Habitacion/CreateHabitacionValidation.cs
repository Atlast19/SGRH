

using FluentValidation;
using SGRH.Application.DTOs.Habitacion.HabitacionDto;

namespace SGRH.Application.Validations.Habitacion.Habitacion
{
    public class CreateHabitacionValidation : AbstractValidator<CreateHabitacionDto>
    {
        public CreateHabitacionValidation()
        {
            RuleFor(x => x.Numero)
            .NotEmpty()
            .MaximumLength(10)
            .Matches(@"^[a-zA-Z0-9]+$");

            RuleFor(x => x.Detalle)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.Precio)
                .GreaterThan(0);

            RuleFor(x => x.IdEstadoHabitacion)
                .GreaterThan(0);

            RuleFor(x => x.IdPiso)
                .GreaterThan(0);

            RuleFor(x => x.IdCategoria)
                .GreaterThan(0);

            RuleFor(x => x.UsuarioCreacion)
                .GreaterThan(0);
        }
    }
}
