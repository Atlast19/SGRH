using FluentValidation;
using SGRH.Application.DTOs.Reserva.ServicioDto;

namespace SGRH.Application.Validations.Servicios.Servicio
{
    public class UpdateServicioValidation : AbstractValidator<UpdateServicioDto>
    {
        public UpdateServicioValidation()
        {
            RuleFor(x => x.IdServicio)
                .NotEmpty()
                .NotEqual(0);


            RuleFor(x => x.Nombre)
                .NotEmpty()
                .Matches(@"^[\p{L}\s]+$")
                .MaximumLength(60);


            RuleFor(x => x.Descripcion)
                .NotEmpty()
                .Matches(@"^[\p{L}\s]+$")
                .MaximumLength(200);

            RuleFor(x => x.UsuarioActualizacion)
                .NotEmpty()
                .NotEqual(0);
        }
    }
}
