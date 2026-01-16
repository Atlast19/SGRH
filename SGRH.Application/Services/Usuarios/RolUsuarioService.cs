
using SGRH.Application.DTOs.Usuarios;
using SGRH.Application.Interfaces.Usuarios;
using SGRH.Domein.Base;
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

        public async Task<OperationResult<RolUsuarioDTO>> CreateAsync(RolUsuarioDTO dto)
        {
            var RolUsuario = new RolUsuario();

            RolUsuario.Descripcion = dto.Descripcion;
            RolUsuario.UsuarioCreacion = dto.UsuarioCreacion;
            RolUsuario.FechaCreacion = DateTime.Now;
            RolUsuario.Estado = true;
            RolUsuario.Borrado = false;

            await _repository.CreateAsync(RolUsuario);

            var resultDto = new RolUsuarioDTO
            {
                IdRolUsuario = RolUsuario.IdRolUsuario,
                Descripcion = RolUsuario.Descripcion,
                Estado = RolUsuario.Estado,
                UsuarioCreacion = RolUsuario.UsuarioCreacion,
                FechaCreacion = RolUsuario.FechaCreacion,
                UsuarioEliminacion = RolUsuario.UsuarioEliminacion,
                FechaEliminado = RolUsuario.FechaEliminado,
                UsuarioActualizacion = RolUsuario.UsuarioActualizacion,
                FechaActualizacion = RolUsuario.FechaActualizacion,
                Borrado = RolUsuario.Borrado
            };

            return OperationResult<RolUsuarioDTO>.Succes("Datos agregados correctamente", resultDto);
        }

        public async Task<OperationResult<RolUsuarioDTO>> DeleteAsync(int Id, int IdUsuario)
        {
           var RolUsuario = await _repository.GetByIdAsync(Id);

            if (RolUsuario == null || RolUsuario.Borrado)
                return OperationResult<RolUsuarioDTO>.Failure("No se encontraron los datos a eliminar");

            RolUsuario.Borrado = true;
            RolUsuario.Estado = false;
            RolUsuario.UsuarioEliminacion = IdUsuario;
            RolUsuario.FechaEliminado = DateTime.Now;

            await _repository.UpdateAsync(RolUsuario);

            var resultDto = new RolUsuarioDTO
            {
                IdRolUsuario = RolUsuario.IdRolUsuario,
                Descripcion = RolUsuario.Descripcion,
                Estado = RolUsuario.Estado,
                UsuarioCreacion = RolUsuario.UsuarioCreacion,
                FechaCreacion = RolUsuario.FechaCreacion,
                UsuarioEliminacion = RolUsuario.UsuarioEliminacion,
                FechaEliminado = RolUsuario.FechaEliminado,
                UsuarioActualizacion = RolUsuario.UsuarioActualizacion,
                FechaActualizacion = RolUsuario.FechaActualizacion,
                Borrado = RolUsuario.Borrado
            };

            return OperationResult<RolUsuarioDTO>.Succes("Datos eliminados correctamente", resultDto);
        }

        public async Task<OperationResult<IEnumerable<RolUsuarioDTO>>> GetAllAsync()
        {
            var RolUsuario = await _repository.GetAllAsync();

            if (!RolUsuario.Any())
                return OperationResult<IEnumerable<RolUsuarioDTO>>.Failure("No se encontraron datos");

            var dto = RolUsuario.Where(c => !c.Borrado)
                .Select(c => new RolUsuarioDTO 
                {
                    IdRolUsuario = c.IdRolUsuario,
                    Descripcion = c.Descripcion,
                    Estado = c.Estado,
                    UsuarioCreacion = c.UsuarioCreacion,
                    FechaCreacion = c.FechaCreacion,
                    UsuarioEliminacion = c.UsuarioEliminacion,
                    FechaEliminado = c.FechaEliminado,
                    UsuarioActualizacion = c.UsuarioActualizacion,
                    FechaActualizacion = c.FechaActualizacion,
                    Borrado = c.Borrado
                });

            return OperationResult<IEnumerable<RolUsuarioDTO>>.Succes("Datos cargados correctamente",dto);
        }

        public async Task<OperationResult<RolUsuarioDTO>> GetByIdAsync(int Id)
        {
            var RolUsuario = await _repository.GetByIdAsync(Id);

            if (RolUsuario == null || RolUsuario.Borrado)
                return OperationResult<RolUsuarioDTO>.Failure("No se encontraron los datos solicitados");

            var resultDto = new RolUsuarioDTO
            {
                IdRolUsuario = RolUsuario.IdRolUsuario,
                Descripcion = RolUsuario.Descripcion,
                Estado = RolUsuario.Estado,
                UsuarioCreacion = RolUsuario.UsuarioCreacion,
                FechaCreacion = RolUsuario.FechaCreacion,
                UsuarioEliminacion = RolUsuario.UsuarioEliminacion,
                FechaEliminado = RolUsuario.FechaEliminado,
                UsuarioActualizacion = RolUsuario.UsuarioActualizacion,
                FechaActualizacion = RolUsuario.FechaActualizacion,
                Borrado = RolUsuario.Borrado
            };

            return OperationResult<RolUsuarioDTO>.Succes("Datos cargados correctamente", resultDto);
        }

        public async Task<OperationResult<RolUsuarioDTO>> UpdateAsync(RolUsuarioDTO dto)
        {
            if (dto.Borrado)
                return OperationResult<RolUsuarioDTO>.Failure("No se entontraron los datos");

            var RolUsuario = new RolUsuario();

            RolUsuario.Descripcion = dto.Descripcion;
            RolUsuario.UsuarioActualizacion = dto.UsuarioActualizacion;
            RolUsuario.FechaActualizacion = DateTime.Now;

            await _repository.UpdateAsync(RolUsuario);

            var resultDto = new RolUsuarioDTO
            {
                IdRolUsuario = RolUsuario.IdRolUsuario,
                Descripcion = RolUsuario.Descripcion,
                Estado = RolUsuario.Estado,
                UsuarioCreacion = RolUsuario.UsuarioCreacion,
                FechaCreacion = RolUsuario.FechaCreacion,
                UsuarioEliminacion = RolUsuario.UsuarioEliminacion,
                FechaEliminado = RolUsuario.FechaEliminado,
                UsuarioActualizacion = RolUsuario.UsuarioActualizacion,
                FechaActualizacion = RolUsuario.FechaActualizacion,
                Borrado = RolUsuario.Borrado
            };

            return OperationResult<RolUsuarioDTO>.Succes("Datos actualizados correctamente", resultDto);
        }
    }
}
