using FluentValidation;
using SGRH.Application.DTOs.Reserva.ReservaDto;

namespace SGRH.Application.Validations.Servicios.Reserva
{
    public class DeleteReservaValidation : AbstractValidator<DeleteReservaDto>
    {
        public DeleteReservaValidation()
        {
            
        }
    }
}
