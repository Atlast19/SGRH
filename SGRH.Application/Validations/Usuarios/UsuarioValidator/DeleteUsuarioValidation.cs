

using FluentValidation;
using SGRH.Application.DTOs.Usuarios.UsuarioDto;

namespace SGRH.Application.Validations.Usuarios.UsuarioValidator
{
    public class DeleteUsuarioValidation : AbstractValidator<DeleteUsuarioDto>
    {
        public DeleteUsuarioValidation()
        {
            
        }
    }
}
