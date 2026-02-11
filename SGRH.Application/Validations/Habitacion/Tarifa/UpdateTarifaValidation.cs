using FluentValidation;
using SGRH.Application.DTOs.Habitacion.TarifaDto;

namespace SGRH.Application.Validations.Habitacion.Tarifa
{
    public class UpdateTarifaValidation : AbstractValidator<UpdateTarifaDto>
    {
        public UpdateTarifaValidation()
        {
            
        }
    }
}
