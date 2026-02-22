using FluentValidation;
using SGRH.Application.DTOs.Habitacion.CategoriumDto;

namespace SGRH.Application.Validations.Habitacion.Categorium
{
    public class UpdateCategoriumValidation : AbstractValidator<UpdateCategoriumDto>
    {
        public UpdateCategoriumValidation()
        {
            RuleFor(x => x.Descripcion)
                .NotEmpty()
                .Matches(@"^[\p{L}\s]+$")
                .MaximumLength(50);


            RuleFor(x => x.IdServicio)
                .GreaterThan(0);

            RuleFor(x => x.UsuarioActualizacion)
                .GreaterThan(0);
        }
    }
}
