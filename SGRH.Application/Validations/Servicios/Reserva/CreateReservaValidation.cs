using FluentValidation;
using SGRH.Application.DTOs.Reserva.ReservaDto;

namespace SGRH.Application.Validations.Servicios.Reserva
{
    public class CreateReservaValidation : AbstractValidator<CreateReservaDto>
    {
        public CreateReservaValidation()
        {
            RuleFor(x => x.IdCliente)
                .NotEmpty()
                .NotEqual(0);

            RuleFor(x => x.IdHabitacion)
                .NotEmpty()
                .NotEqual(0);

            RuleFor(x => x.FechaEntrada)
                .NotEmpty();

            RuleFor(x => x.FechaSalida)
                .GreaterThan(x => x.FechaEntrada)
                .WithMessage("La fecha de salida debe ser mayor que la fecha de entrada");

            RuleFor(x => x.FechaSalidaConfirmacion)
                .GreaterThanOrEqualTo(x => x.FechaSalida)
                .WithMessage("La fecha de confirmación debe ser igual o posterior a la salida");

            RuleFor(x => x.PrecioInicial)
                .GreaterThan(0);

            RuleFor(x => x.Adelanto)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(x => x.PrecioInicial);

            RuleFor(x => x.PrecioRestante)
                .GreaterThanOrEqualTo(0);
               
            RuleFor(x => x.TotalPagado)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(x => x.PrecioInicial);

            RuleFor(x => x.CostoPenalidad)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x)
                .Must(x => x.PrecioRestante == x.PrecioInicial - x.Adelanto)
                .WithMessage("El precio restante debe ser igual a PrecioInicial - Adelanto");

            RuleFor(x => x.Observacion)
                .Matches(@"^[\p{L}\s]+$");

            RuleFor(x => x.UsuarioCreacion)
                .NotEmpty()
                .NotEqual(0);
        }
    }
}
