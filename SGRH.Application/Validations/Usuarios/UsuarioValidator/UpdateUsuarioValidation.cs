using FluentValidation;
using SGRH.Application.DTOs.Usuarios.UsuarioDto;


namespace SGRH.Application.Validations.Usuarios.UsuarioValidator
{
    internal class UpdateUsuarioValidation : AbstractValidator<UpdateUsuarioDto>
    {
        public UpdateUsuarioValidation()
        {
            
        }
    }
}
