using SGRH.Application.DTOs.Usuarios.RolUsuarioDto;
using SGRH.Application.Interfaces.Usuarios;
using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Usuarios;

namespace SGRH.Application.Services.Usuarios
{
    public class RolUsuarioService : IRolUsuarioService
    {
        private readonly IRolUsuarioRepository _repository;

        public RolUsuarioService(IRolUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateRolUsuarioDto> CreateAsync(CreateRolUsuarioDto dto)
        {
            var RolUsuario = new RolUsuario();

            RolUsuario.Descripcion = dto.Descripcion;
            RolUsuario.UsuarioCreacion = dto.UsuarioCreacion;
            RolUsuario.FechaCreacion = DateTime.Now;
            RolUsuario.Estado = true;

            await _repository.CreateAsync(RolUsuario);

            var resultDto = new CreateRolUsuarioDto
            {
                Descripcion = RolUsuario.Descripcion,
                Estado = RolUsuario.Estado,
                UsuarioCreacion = RolUsuario.UsuarioCreacion,
                FechaCreacion = RolUsuario.FechaCreacion
            };

            return resultDto;
        }

        public async Task<DeleteRolUsuarioDto> DeleteAsync(int Id, int IdUsuario)
        {
           var RolUsuario = await _repository.GetByIdAsync(Id);

            RolUsuario.Borrado = true;
            RolUsuario.Estado = false;
            RolUsuario.UsuarioEliminacion = IdUsuario;
            RolUsuario.FechaEliminado = DateTime.Now;

            await _repository.UpdateAsync(RolUsuario);

            var resultDto = new DeleteRolUsuarioDto
            {
                IdRolUsuario = RolUsuario.IdRolUsuario,
                Estado = RolUsuario.Estado,
                UsuarioEliminacion = RolUsuario.UsuarioEliminacion,
                FechaEliminado = RolUsuario.FechaEliminado,
                Borrado = RolUsuario.Borrado
            };

            return resultDto;
        }

        public async Task<IEnumerable<ReadRolUsuarioDto>> GetAllAsync()
        {
            var RolUsuario = await _repository.GetAllAsync();

            var dto = RolUsuario.Where(c => !c.Borrado)
                .Select(c => new ReadRolUsuarioDto 
                {
                    IdRolUsuario = c.IdRolUsuario,
                    Descripcion = c.Descripcion
                });

            return dto;
        }

        public async Task<ReadRolUsuarioDto> GetByIdAsync(int Id)
        {
            var RolUsuario = await _repository.GetByIdAsync(Id);

            var resultDto = new ReadRolUsuarioDto
            {
                IdRolUsuario = RolUsuario.IdRolUsuario,
                Descripcion = RolUsuario.Descripcion
            };

            return resultDto;
        }

        public async Task<UpdateRolUsuarioDto> UpdateAsync(UpdateRolUsuarioDto dto)
        {
           var RolUsuario = await _repository.GetByIdAsync(dto.IdRolUsuario);

            RolUsuario.Descripcion = dto.Descripcion;
            RolUsuario.UsuarioActualizacion = dto.UsuarioActualizacion;
            RolUsuario.FechaActualizacion = DateTime.Now;

            await _repository.UpdateAsync(RolUsuario);

            var resultDto = new UpdateRolUsuarioDto
            {
                IdRolUsuario = RolUsuario.IdRolUsuario,
                Descripcion = RolUsuario.Descripcion,
                UsuarioActualizacion = RolUsuario.UsuarioActualizacion,
                FechaActualizacion = RolUsuario.FechaActualizacion
            };

            return resultDto;
        }
    }
}
