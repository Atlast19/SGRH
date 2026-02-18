using FluentValidation;
using SGRH.Application.DTOs.Habitacion.PisoDto;

namespace SGRH.Application.Validations.Habitacion.Piso
{
    public class ReadPisoValidation : AbstractValidator<ReadPisoDto>
    {
        public ReadPisoValidation()
        {
            
        }
    }
}
