using FluentValidation;
using SGRH.Application.DTOs.Reserva.ReservaDto;

namespace SGRH.Application.Validations.Servicios.Reserva
{
    public class CreateReservaValidation : AbstractValidator<CreateReservaDto>
    {
        public CreateReservaValidation()
        {
            
        }
    }
}
