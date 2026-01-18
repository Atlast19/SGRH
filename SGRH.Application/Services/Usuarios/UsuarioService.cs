

using SGRH.Application.DTOs.Usuarios;
using SGRH.Application.Interfaces.Usuarios;
using SGRH.Domein.Base;
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

        public async Task<OperationResult<UsuarioDTO>> CreateAsync(UsuarioDTO dto)
        {

            //Prender FluentValidation para aplicar las validaciones de los campos correspondientes

            var usuario = new Usuario();

            usuario.NombreCompleto = dto.NombreCompleto;
            usuario.Correo = dto.Correo;
            usuario.IdRolUsuario = dto.IdRolUsuario;
            usuario.Clave = dto.Clave;
            usuario.Estado = true;
            usuario.Borrado = false;
            usuario.UsuarioCreacion = dto.UsuarioCreacion;
            usuario.FechaCreacion = DateTime.Now;

            await _repository.CreateAsync(usuario);

            var resultDto = new UsuarioDTO
            {
                IdUsuario = usuario.IdUsuario,
                NombreCompleto = usuario.NombreCompleto,
                Correo = usuario.Correo,
                Clave = usuario.Clave,
                IdRolUsuario = usuario.IdUsuario,
                UsuarioCreacion = usuario.UsuarioCreacion,
                FechaCreacion = usuario.FechaCreacion,
                UsuarioEliminacion = usuario.UsuarioEliminacion,
                FechaEliminado = usuario.FechaEliminado,
                UsuarioActualizacion = usuario.UsuarioActualizacion,
                FechaActualizacion = usuario.FechaActualizacion,
                Borrado = usuario.Borrado,
                Estado = usuario.Estado
            };

            return OperationResult<UsuarioDTO>.Succes("Categoría creada correctamente", resultDto);
        }

        public async Task<OperationResult<UsuarioDTO>> DeleteAsync(int Id, int IdUsuario)
        {
            var usuario = await _repository.GetByIdAsync(Id);

            if (usuario == null || usuario.Borrado)
                return OperationResult<UsuarioDTO>.Failure("No se encontraron los datos a eliminar");

            usuario.Borrado = true;
            usuario.Estado = false;
            usuario.UsuarioEliminacion = IdUsuario;
            usuario.FechaEliminado = DateTime.Now;

            await _repository.UpdateAsync(usuario);

            var resultDto = new UsuarioDTO
            {
                IdUsuario = usuario.IdUsuario,
                NombreCompleto = usuario.NombreCompleto,
                Correo = usuario.Correo,
                Clave = usuario.Clave,
                IdRolUsuario = usuario.IdUsuario,
                UsuarioCreacion = usuario.UsuarioCreacion,
                FechaCreacion = usuario.FechaCreacion,
                UsuarioEliminacion = usuario.UsuarioEliminacion,
                FechaEliminado = usuario.FechaEliminado,
                UsuarioActualizacion = usuario.UsuarioActualizacion,
                FechaActualizacion = usuario.FechaActualizacion,
                Borrado = usuario.Borrado,
                Estado = usuario.Estado
            };

            return OperationResult<UsuarioDTO>.Succes("Datos eliminados correctamente",resultDto);
        }

        public async Task<OperationResult<IEnumerable<UsuarioDTO>>> GetAllAsync()
        {
            var usuario = await _repository.GetAllAsync();

            if (!usuario.Any())
                return OperationResult<IEnumerable<UsuarioDTO>>.Failure("No se encontraron los datos solicitados");


            var dto = usuario.Where(c => !c.Borrado)
                .Select(c => new UsuarioDTO
                {
                    IdUsuario = c.IdUsuario,
                    NombreCompleto = c.NombreCompleto,
                    Clave = c.Clave,
                    Correo = c.Correo,
                    IdRolUsuario = c.IdUsuario,
                    UsuarioCreacion = c.UsuarioCreacion,
                    FechaCreacion = c.FechaCreacion,
                    UsuarioEliminacion = c.UsuarioEliminacion,
                    FechaEliminado = c.FechaEliminado,
                    UsuarioActualizacion = c.UsuarioActualizacion,
                    FechaActualizacion = c.FechaActualizacion,
                    Borrado = c.Borrado,
                    Estado = c.Estado
                });

            return OperationResult<IEnumerable<UsuarioDTO>>.Succes("Datos cargados correctamente", dto);
        }

        public async Task<OperationResult<UsuarioDTO>> GetByIdAsync(int Id)
        {
            var usuario = await _repository.GetByIdAsync(Id);

            if (usuario == null || usuario.Borrado)
                return OperationResult<UsuarioDTO>.Failure("No se encontraron los datos solicitados");


            var dto =  new UsuarioDTO
            {
                IdUsuario = usuario.IdUsuario,
                NombreCompleto = usuario.NombreCompleto,
                Correo = usuario.Correo,
                Clave = usuario.Clave,
                IdRolUsuario = usuario.IdUsuario,
                UsuarioCreacion = usuario.UsuarioCreacion,
                FechaCreacion = usuario.FechaCreacion,
                UsuarioEliminacion = usuario.UsuarioEliminacion,
                FechaEliminado = usuario.FechaEliminado,
                UsuarioActualizacion = usuario.UsuarioActualizacion,
                FechaActualizacion = usuario.FechaActualizacion,
                Borrado = usuario.Borrado,
                Estado = usuario.Estado
            };

            return OperationResult<UsuarioDTO>.Succes("Datos cargados correctamente", dto);
        }

        public async Task<OperationResult<UsuarioDTO>> UpdateAsync(UsuarioDTO dto)
        {

           var usuario = await _repository.GetByIdAsync(dto.IdUsuario);

            if (usuario == null || usuario.Borrado)
                return OperationResult<UsuarioDTO>.Failure("No se encontralos los datos a actualizar");
            

            usuario.NombreCompleto = dto.NombreCompleto;
            usuario.Correo = dto.Correo;
            usuario.IdRolUsuario = dto.IdRolUsuario;
            usuario.Clave = dto.Clave;
            usuario.UsuarioActualizacion = dto.UsuarioActualizacion;
            usuario.FechaActualizacion = DateTime.Now;

            await _repository.UpdateAsync(usuario);

            var resultDto = new UsuarioDTO
            {
                IdUsuario = usuario.IdUsuario,
                NombreCompleto = usuario.NombreCompleto,
                Correo = usuario.Correo,
                Clave = usuario.Clave,
                IdRolUsuario = usuario.IdUsuario,
                UsuarioCreacion = usuario.UsuarioCreacion,
                FechaCreacion = usuario.FechaCreacion,
                UsuarioEliminacion = usuario.UsuarioEliminacion,
                FechaEliminado = usuario.FechaEliminado,
                UsuarioActualizacion = usuario.UsuarioActualizacion,
                FechaActualizacion = usuario.FechaActualizacion,
                Borrado = usuario.Borrado,
                Estado = usuario.Estado
            };

            return OperationResult<UsuarioDTO>.Succes("Datos actualizados correctmente", resultDto);

        }
    }
}
