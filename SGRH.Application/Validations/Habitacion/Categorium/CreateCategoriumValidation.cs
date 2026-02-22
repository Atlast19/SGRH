using FluentValidation;
using SGRH.Application.DTOs.Habitacion.CategoriumDto;

namespace SGRH.Application.Validations.Habitacion.Categorium
{
    public class CreateCategoriumValidation : AbstractValidator<CreateCategoriumDto>
    {
        public CreateCategoriumValidation()
        {
            RuleFor(x => x.Descripcion)
                .NotEmpty()
                .Matches(@"^[\p{L}\s]+$")
                .MaximumLength(50);


            RuleFor(x => x.IdServicio)
                .GreaterThan(0);

            RuleFor(x => x.UsuarioCreacion)
                .GreaterThan(0);
        }
    }
}
