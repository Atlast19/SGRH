using SGRH.Application.DTOs.Usuarios.UsuarioDto;
using SGRH.Application.Interfaces.Usuarios;
using SGRH.Application.Validations.Habitacion.Categorium;
using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Usuarios;

namespace SGRH.Application.Services.Usuarios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateUsuarioDto> CreateAsync(CreateUsuarioDto dto)
        {

            var usuario = new Usuario();


            usuario.NombreCompleto = dto.NombreCompleto;
            usuario.Correo = dto.Correo;
            usuario.IdRolUsuario = dto.IdRolUsuario;
            usuario.Clave = dto.Clave;

            usuario.Estado = true;
            usuario.UsuarioCreacion = dto.UsuarioCreacion;
            usuario.FechaCreacion = DateTime.Now;

            await _repository.CreateAsync(usuario);

            var resultDto = new CreateUsuarioDto
            {
                NombreCompleto = usuario.NombreCompleto,
                Correo = usuario.Correo,
                Clave = usuario.Clave,
                IdRolUsuario = usuario.IdRolUsuario,
                UsuarioCreacion = usuario.UsuarioCreacion,
                
            };

            return resultDto;
        }

        public async Task<DeleteUsuarioDto> DeleteAsync(int Id, int IdUsuario)
        {
            var usuario = await _repository.GetByIdAsync(Id);

            usuario.Borrado = true;
            usuario.Estado = false;
            usuario.UsuarioEliminacion = IdUsuario;
            usuario.FechaEliminado = DateTime.Now;

            await _repository.UpdateAsync(usuario);

            var resultDto = new DeleteUsuarioDto
            {
                IdUsuario = usuario.IdUsuario,
                UsuarioEliminacion = usuario.UsuarioEliminacion
            };

            return resultDto;
        }

        public async Task<IEnumerable<ReadUsuarioDto>> GetAllAsync()
        {
            var usuario = await _repository.GetAllAsync();


            var dto = usuario.Where(c => !c.Borrado)
                .Select(c => new ReadUsuarioDto
                {
                    IdUsuario = c.IdUsuario,
                    NombreCompleto = c.NombreCompleto,
                    Correo = c.Correo,
                    IdRolUsuario = c.IdRolUsuario,
                    Clave = c.Clave
                });

            return dto;
        }

        public async Task<ReadUsuarioDto> GetByIdAsync(int Id)
        {
            var usuario = await _repository.GetByIdAsync(Id);

            var dto =  new ReadUsuarioDto
            {
                IdUsuario = usuario.IdUsuario,
                NombreCompleto = usuario.NombreCompleto,
                Correo = usuario.Correo,
                IdRolUsuario = usuario.IdRolUsuario,
                Clave = usuario.Clave
            };

            return dto;
        }

        public async Task<UpdateUsuarioDto> UpdateAsync(UpdateUsuarioDto dto)
        {

           var usuario = await _repository.GetByIdAsync(dto.IdUsuario);

            usuario.NombreCompleto = dto.NombreCompleto;
            usuario.Correo = dto.Correo;
            usuario.IdRolUsuario = dto.IdRolUsuario;
            usuario.Clave = dto.Clave;
            usuario.UsuarioActualizacion = dto.UsuarioActualizacion;
            usuario.FechaActualizacion = DateTime.Now;

            await _repository.UpdateAsync(usuario);

            var resultDto = new UpdateUsuarioDto
            {
                IdUsuario = usuario.IdUsuario,
                NombreCompleto = usuario.NombreCompleto,
                Correo = usuario.Correo,
                Clave = usuario.Clave,
                IdRolUsuario = usuario.IdUsuario,
                UsuarioActualizacion = usuario.UsuarioActualizacion

            };

            return resultDto;

        }
    }
}
