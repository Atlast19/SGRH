using SGRH.Application.DTOs.Usuarios.ClienteDto;
using SGRH.Application.Interfaces.Usuarios;
using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Usuarios;

namespace SGRH.Application.Services.Usuarios
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateClienteDto> CreateAsync(CreateClienteDto dto)
        {
            var Cliente = new Cliente();

            Cliente.NombreCompleto = dto.NombreCompleto;
            Cliente.TipoDocumento = dto.TipoDocumento;
            Cliente.Documento = dto.Documento;
            Cliente.Correo = dto.Correo;
            Cliente.Estado = true;
            Cliente.UsuarioCreacion = dto.UsuarioCreacion;
            Cliente.FechaCreacion = DateTime.Now;

            await _repository.CreateAsync(Cliente);

            var resultDto = new CreateClienteDto 
            {
                NombreCompleto = Cliente.NombreCompleto,
                TipoDocumento = Cliente.TipoDocumento,
                Documento = Cliente.Documento,
                Correo = Cliente.Correo,
                Estado = Cliente.Estado,
                UsuarioCreacion = Cliente.UsuarioCreacion,
                FechaCreacion = Cliente.FechaCreacion
            };

            return resultDto;
        }

        public async Task<DeleteClienteDto> DeleteAsync(int Id, int IdUsuario)
        {
            var Cliente = await _repository.GetByIdAsync(Id);

            Cliente.Borrado = true;
            Cliente.Estado = false;
            Cliente.UsuarioEliminacion = IdUsuario;
            Cliente.FechaEliminado = DateTime.Now;

            await _repository.UpdateAsync(Cliente);

            var resultDto = new DeleteClienteDto
            {
                IdCliente = Cliente.IdCliente,
                Estado = Cliente.Estado,
                UsuarioEliminacion = Cliente.UsuarioEliminacion,
                FechaEliminado = Cliente.FechaEliminado,
                Borrado = Cliente.Borrado
            };

            return resultDto;
        }

        public async Task<IEnumerable<ReadClienteDto>> GetAllAsync()
        {
            var Cliente = await _repository.GetAllAsync();

            var dto = Cliente.Where(c => !c.Borrado)
                .Select(c => new ReadClienteDto 
                {
                    IdCliente = c.IdCliente,
                    NombreCompleto = c.NombreCompleto,
                    TipoDocumento = c.TipoDocumento,
                    Documento = c.Documento,
                    Correo = c.Correo
                });

            return dto;
        }

        public async Task<ReadClienteDto> GetByIdAsync(int Id)
        {
            var Cliente = await _repository.GetByIdAsync(Id);

            var resultDto = new ReadClienteDto
            {
                IdCliente = Cliente.IdCliente,
                NombreCompleto = Cliente.NombreCompleto,
                TipoDocumento = Cliente.TipoDocumento,
                Documento = Cliente.Documento,
                Correo = Cliente.Correo
            };

            return resultDto;
        }

        public async Task<UpdateClienteDto> UpdateAsync(UpdateClienteDto dto)
        {
           var Cliente = await _repository.GetByIdAsync(dto.IdCliente);


            Cliente.NombreCompleto = dto.NombreCompleto;
            Cliente.TipoDocumento = dto.TipoDocumento;
            Cliente.Documento = dto.Documento;
            Cliente.Correo = dto.Correo;
            Cliente.UsuarioActualizacion = dto.UsuarioActualizacion;
            Cliente.FechaActualizacion = DateTime.Now;

            await _repository.UpdateAsync(Cliente);

            var resultDto = new UpdateClienteDto
            {
                IdCliente = Cliente.IdCliente,
                NombreCompleto = Cliente.NombreCompleto,
                TipoDocumento = Cliente.TipoDocumento,
                Documento = Cliente.Documento,
                Correo = Cliente.Correo,
                UsuarioActualizacion = Cliente.UsuarioActualizacion,
                FechaActualizacion = Cliente.FechaActualizacion
            };

            return resultDto;
        }
    }
}
