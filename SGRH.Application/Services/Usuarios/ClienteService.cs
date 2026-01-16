using SGRH.Application.DTOs.Usuarios;
using SGRH.Application.Interfaces.Usuarios;
using SGRH.Domein.Base;
using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Usuarios;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace SGRH.Application.Services.Usuarios
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult<ClienteDTO>> CreateAsync(ClienteDTO dto)
        {
            var Cliente = new Cliente();

            Cliente.NombreCompleto = dto.NombreCompleto;
            Cliente.TipoDocumento = dto.TipoDocumento;
            Cliente.Documento = dto.Documento;
            Cliente.Correo = dto.Correo;
            Cliente.Estado = true;
            Cliente.Borrado = false;
            Cliente.UsuarioCreacion = dto.UsuarioCreacion;
            Cliente.FechaCreacion = DateTime.Now;

            await _repository.CreateAsync(Cliente);

            var resultDto = new ClienteDTO 
            {
                IdCliente = Cliente.IdCliente,
                NombreCompleto = Cliente.NombreCompleto,
                TipoDocumento = Cliente.TipoDocumento,
                Documento = Cliente.Documento,
                Correo = Cliente.Correo,
                Estado = Cliente.Estado,
                UsuarioCreacion = Cliente.UsuarioCreacion,
                FechaCreacion = Cliente.FechaCreacion,
                UsuarioEliminacion = Cliente.UsuarioEliminacion,
                FechaEliminado = Cliente.FechaEliminado,
                UsuarioActualizacion = Cliente.UsuarioActualizacion,
                FechaActualizacion = Cliente.FechaActualizacion,
                Borrado = Cliente.Borrado
            };

            return OperationResult<ClienteDTO>.Succes("Datos agregados correctamente", resultDto);
        }

        public async Task<OperationResult<ClienteDTO>> DeleteAsync(int Id, int IdUsuario)
        {
            var Cliente = await _repository.GetByIdAsync(Id);

            if (Cliente == null || Cliente.Borrado)
                return OperationResult<ClienteDTO>.Failure("No se encontraron los datos a eliminar");

            Cliente.Borrado = true;
            Cliente.Estado = false;
            Cliente.UsuarioCreacion = IdUsuario;
            Cliente.FechaEliminado = DateTime.Now;

            await _repository.UpdateAsync(Cliente);

            var resultDto = new ClienteDTO
            {
                IdCliente = Cliente.IdCliente,
                NombreCompleto = Cliente.NombreCompleto,
                TipoDocumento = Cliente.TipoDocumento,
                Documento = Cliente.Documento,
                Correo = Cliente.Correo,
                Estado = Cliente.Estado,
                UsuarioCreacion = Cliente.UsuarioCreacion,
                FechaCreacion = Cliente.FechaCreacion,
                UsuarioEliminacion = Cliente.UsuarioEliminacion,
                FechaEliminado = Cliente.FechaEliminado,
                UsuarioActualizacion = Cliente.UsuarioActualizacion,
                FechaActualizacion = Cliente.FechaActualizacion,
                Borrado = Cliente.Borrado
            };

            return OperationResult<ClienteDTO>.Succes("Datos eliminados correctamente", resultDto);
        }

        public async Task<OperationResult<IEnumerable<ClienteDTO>>> GetAllAsync()
        {
            var Cliente = await _repository.GetAllAsync();

            if (!Cliente.Any())
                return OperationResult<IEnumerable<ClienteDTO>>.Failure("No se encontraron los datos");

            var dto = Cliente.Where(c => !c.Borrado)
                .Select(c => new ClienteDTO 
                {
                    IdCliente = c.IdCliente,
                    NombreCompleto = c.NombreCompleto,
                    TipoDocumento = c.TipoDocumento,
                    Documento = c.Documento,
                    Correo = c.Correo,
                    Estado = c.Estado,
                    UsuarioCreacion = c.UsuarioCreacion,
                    FechaCreacion = c.FechaCreacion,
                    UsuarioEliminacion = c.UsuarioEliminacion,
                    FechaEliminado = c.FechaEliminado,
                    UsuarioActualizacion = c.UsuarioActualizacion,
                    FechaActualizacion = c.FechaActualizacion,
                    Borrado = c.Borrado
                });

            return OperationResult<IEnumerable<ClienteDTO>>.Succes("Datos cargado correctmanete", dto);
        }

        public async Task<OperationResult<ClienteDTO>> GetByIdAsync(int Id)
        {
            var Cliente = await _repository.GetByIdAsync(Id);

            if (Cliente == null || Cliente.Borrado)
                return OperationResult<ClienteDTO>.Failure("No se encontraron los datos solicitados");

            var resultDto = new ClienteDTO
            {
                IdCliente = Cliente.IdCliente,
                NombreCompleto = Cliente.NombreCompleto,
                TipoDocumento = Cliente.TipoDocumento,
                Documento = Cliente.Documento,
                Correo = Cliente.Correo,
                Estado = Cliente.Estado,
                UsuarioCreacion = Cliente.UsuarioCreacion,
                FechaCreacion = Cliente.FechaCreacion,
                UsuarioEliminacion = Cliente.UsuarioEliminacion,
                FechaEliminado = Cliente.FechaEliminado,
                UsuarioActualizacion = Cliente.UsuarioActualizacion,
                FechaActualizacion = Cliente.FechaActualizacion,
                Borrado = Cliente.Borrado
            };

            return OperationResult<ClienteDTO>.Succes("Datos cargados correctamente", resultDto);
        }

        public async Task<OperationResult<ClienteDTO>> UpdateAsync(ClienteDTO dto)
        {
            if (dto.Borrado)
                return OperationResult<ClienteDTO>.Failure("No se encontraron los datos a actualizar");

            var Cliente = new Cliente();

            Cliente.NombreCompleto = dto.NombreCompleto;
            Cliente.TipoDocumento = dto.TipoDocumento;
            Cliente.Documento = dto.Documento;
            Cliente.Correo = dto.Correo;
            Cliente.UsuarioActualizacion = dto.UsuarioActualizacion;
            Cliente.FechaActualizacion = DateTime.Now;

            await _repository.UpdateAsync(Cliente);

            var resultDto = new ClienteDTO
            {
                IdCliente = Cliente.IdCliente,
                NombreCompleto = Cliente.NombreCompleto,
                TipoDocumento = Cliente.TipoDocumento,
                Documento = Cliente.Documento,
                Correo = Cliente.Correo,
                Estado = Cliente.Estado,
                UsuarioCreacion = Cliente.UsuarioCreacion,
                FechaCreacion = Cliente.FechaCreacion,
                UsuarioEliminacion = Cliente.UsuarioEliminacion,
                FechaEliminado = Cliente.FechaEliminado,
                UsuarioActualizacion = Cliente.UsuarioActualizacion,
                FechaActualizacion = Cliente.FechaActualizacion,
                Borrado = Cliente.Borrado
            };

            return OperationResult<ClienteDTO>.Succes("Datos actualizados correctamente", resultDto);
        }
    }
}
