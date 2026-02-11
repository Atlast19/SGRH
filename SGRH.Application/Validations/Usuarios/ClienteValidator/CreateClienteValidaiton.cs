using FluentValidation;
using SGRH.Application.DTOs.Usuarios.ClienteDto;

namespace SGRH.Application.Validations.Usuarios.ClienteValidator
{
    public class CreateClienteValidaiton : AbstractValidator<CreateClienteDto>
    {
        public CreateClienteValidaiton()
        {
            
        }
    }
}
