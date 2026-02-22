using FluentValidation;
using SGRH.Application.DTOs.Habitacion.TarifaDto;

namespace SGRH.Application.Validations.Habitacion.Tarifa
{
    public class CreateTarifaValidation : AbstractValidator<CreateTarifaDto>
    {
        public CreateTarifaValidation()
        {
            var hoy = DateOnly.FromDateTime(DateTime.Today);

            RuleFor(x => x.IdHabitacion)
                .GreaterThan(0);

            RuleFor(x => x.FechaInicio)
                .NotEmpty()
                .GreaterThanOrEqualTo(hoy);

            RuleFor(x => x.FechaFin)
                .GreaterThan(x => x.FechaInicio);

            RuleFor(x => x.PrecioPorNoche)
                .GreaterThan(0);

            RuleFor(x => x.Descuento)
                .InclusiveBetween(0, 100);

            RuleFor(x => x.Descripcion)
                .NotEmpty()
                .Matches(@"^[\p{L}\s]+$")
                .MaximumLength(255);
            
            RuleFor(x => x.UsuarioCreacion)
                .GreaterThan(0);
        }
    }
}
