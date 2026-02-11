using FluentValidation;
using SGRH.Application.DTOs.Habitacion.TarifaDto;

namespace SGRH.Application.Validations.Habitacion.Tarifa
{
    public class CreateTarivaValidation : AbstractValidator<CreateTarifaDto>
    {
        public CreateTarivaValidation()
        {
            
        }
    }
}
