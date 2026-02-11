using FluentValidation;
using SGRH.Application.DTOs.Reserva.ServicioDto;

namespace SGRH.Application.Validations.Servicios.Servicio
{
    public class CreateServicioValidation : AbstractValidator<CreateServicioDto>
    {
        public CreateServicioValidation()
        {
            
        }
    }
}
