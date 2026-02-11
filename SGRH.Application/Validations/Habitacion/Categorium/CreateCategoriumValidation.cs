using FluentValidation;
using SGRH.Application.DTOs.Habitacion.CategoriumDto;

namespace SGRH.Application.Validations.Habitacion.Categorium
{
    public class CreateCategoriumValidation : AbstractValidator<CreateCategoriumDto>
    {
        public CreateCategoriumValidation()
        {
            
        }
    }
}
