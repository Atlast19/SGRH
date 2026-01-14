

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
                NombreCompleto = usuario.NombreCompleto,
                Correo = usuario.Correo,
                IdRolUsuario = usuario.IdUsuario,
                Clave = usuario.Clave,
                UsuarioCreacion = usuario.UsuarioCreacion
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

            return OperationResult<UsuarioDTO>.Succes("Datos eliminados correctamente");
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
                    Correo = c.Correo,
                    IdRolUsuario = c.IdUsuario
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
                IdRolUsuario = usuario.IdUsuario
            };

            return OperationResult<UsuarioDTO>.Succes("Datos cargados correctamente", dto);
        }

        public async Task<OperationResult<UsuarioDTO>> UpdateAsync(UsuarioDTO modelo)
        {
            if (modelo.Borrado)
                return OperationResult<UsuarioDTO>.Failure("No se encontralos los datos a actualizar");

            var usuario = new Usuario();
            
            usuario.NombreCompleto = modelo.NombreCompleto;
            usuario.Correo = modelo.Correo;
            usuario.IdRolUsuario = modelo.IdRolUsuario;
            usuario.Clave = modelo.Clave;
            usuario.UsuarioActualizacion = modelo.UsuarioActualizacion;
            usuario.FechaActualizacion = DateTime.Now;


            await _repository.UpdateAsync(usuario);


            return OperationResult<UsuarioDTO>.Succes("Datos actualizados correctmente");


        }
    }
}
