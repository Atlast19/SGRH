using FluentValidation;
using SGRH.Application.DTOs.Reserva.ReservaDto;

namespace SGRH.Application.Validations.Servicios.Reserva
{
    public class CreateReservaValidation : AbstractValidator<CreateReservaDto>
    {
        public CreateReservaValidation()
        {
            RuleFor(x => x.IdCliente)
                .GreaterThan(0);

            RuleFor(x => x.IdHabitacion)
                .GreaterThan(0);

            RuleFor(x => x.FechaEntrada)
                .NotEmpty()
                .GreaterThanOrEqualTo(DateTime.Today);

            RuleFor(x => x.FechaSalida)
                .GreaterThan(x => x.FechaEntrada);

           
            RuleFor(x => x.FechaSalidaConfirmacion)
                .GreaterThanOrEqualTo(x => x.FechaSalida);

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

            RuleFor(x => x.UsuarioCreacion)
                .GreaterThan(0);
        }
    }
}
