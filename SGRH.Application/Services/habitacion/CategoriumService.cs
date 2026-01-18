using SGRH.Application.DTOs.Habitacion;
using SGRH.Application.Interfaces.habitacion;
using SGRH.Domein.Base;
using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Habitaciones;


namespace SGRH.Application.Services.habitacion
{
    public class CategoriumService : ICategoriumService
    {
        private readonly ICategoriumRepository _repository;

        public CategoriumService(ICategoriumRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult<CategoriumDTO>> CreateAsync(CategoriumDTO dto)
        {
            var Categoria = new Categorium();

            Categoria.Descripcion = dto.Descripcion;
            Categoria.IdServicio = dto.IdServicio;
            Categoria.Estado = true;
            Categoria.UsuarioCreacion = dto.UsuarioCreacion;
            Categoria.FechaCreacion = DateTime.Now;

            await _repository.CreateAsync(Categoria);

            var resultDto = new CategoriumDTO
            {
                IdCategoria = Categoria.IdCategoria,
                Descripcion = Categoria.Descripcion,
                IdServicio = Categoria.IdServicio,
                Estado = Categoria.Estado,
                UsuarioCreacion = Categoria.UsuarioCreacion,
                FechaCreacion = Categoria.FechaCreacion,
                UsuarioEliminacion = Categoria.UsuarioEliminacion,
                FechaEliminado = Categoria.FechaEliminado,
                UsuarioActualizacion = Categoria.UsuarioActualizacion,
                FechaActualizacion = Categoria.FechaActualizacion,
                Borrado = Categoria.Borrado
            };

            return OperationResult<CategoriumDTO>.Succes("Datos agregados correctamente",resultDto);
        }

        public async Task<OperationResult<CategoriumDTO>> DeleteAsync(int Id, int IdUsuario)
        {
            var Categoria = await _repository.GetByIdAsync(Id);

            if (Categoria == null || Categoria.Borrado)
                return OperationResult<CategoriumDTO>.Failure("No se concontraron los datos a eliminar");

            Categoria.Borrado = true;
            Categoria.Estado = false;
            Categoria.UsuarioEliminacion = IdUsuario;
            Categoria.FechaEliminado = DateTime.Now;

            await _repository.UpdateAsync(Categoria);

            var resultDto = new CategoriumDTO
            {
                IdCategoria = Categoria.IdCategoria,
                Descripcion = Categoria.Descripcion,
                IdServicio = Categoria.IdServicio,
                Estado = Categoria.Estado,
                UsuarioCreacion = Categoria.UsuarioCreacion,
                FechaCreacion = Categoria.FechaCreacion,
                UsuarioEliminacion = Categoria.UsuarioEliminacion,
                FechaEliminado = Categoria.FechaEliminado,
                UsuarioActualizacion = Categoria.UsuarioActualizacion,
                FechaActualizacion = Categoria.FechaActualizacion,
                Borrado = Categoria.Borrado
            };

            return OperationResult<CategoriumDTO>.Succes("Datos eliminado correctamente", resultDto);
        }

        public async Task<OperationResult<IEnumerable<CategoriumDTO>>> GetAllAsync()
        {
            var Categoria = await _repository.GetAllAsync();

            if (!Categoria.Any())
                return OperationResult<IEnumerable<CategoriumDTO>>.Failure("No se encontraron los datos");

            var dto = Categoria.Where(c => !c.Borrado)
                .Select(c => new CategoriumDTO 
                {
                    IdCategoria = c.IdCategoria,
                    Descripcion = c.Descripcion,
                    IdServicio = c.IdServicio,
                    Estado = c.Estado,
                    UsuarioCreacion = c.UsuarioCreacion,
                    FechaCreacion = c.FechaCreacion,
                    UsuarioEliminacion = c.UsuarioEliminacion,
                    FechaEliminado = c.FechaEliminado,
                    UsuarioActualizacion = c.UsuarioActualizacion,
                    FechaActualizacion = c.FechaActualizacion,
                    Borrado = c.Borrado
                });

            return OperationResult<IEnumerable<CategoriumDTO>>.Succes("Datos cargados correctmente",dto);
        }

        public async Task<OperationResult<CategoriumDTO>> GetByIdAsync(int Id)
        {
            var Categoria = await _repository.GetByIdAsync(Id);

            if (Categoria == null || Categoria.Borrado)
                return OperationResult<CategoriumDTO>.Failure("No se encontraron los datos solicitados");

            var resultDto = new CategoriumDTO
            {
                IdCategoria = Categoria.IdCategoria,
                Descripcion = Categoria.Descripcion,
                IdServicio = Categoria.IdServicio,
                Estado = Categoria.Estado,
                UsuarioCreacion = Categoria.UsuarioCreacion,
                FechaCreacion = Categoria.FechaCreacion,
                UsuarioEliminacion = Categoria.UsuarioEliminacion,
                FechaEliminado = Categoria.FechaEliminado,
                UsuarioActualizacion = Categoria.UsuarioActualizacion,
                FechaActualizacion = Categoria.FechaActualizacion,
                Borrado = Categoria.Borrado
            };

            return OperationResult<CategoriumDTO>.Succes("Datos cargados correctamente", resultDto);
        }

        public async Task<OperationResult<CategoriumDTO>> UpdateAsync(CategoriumDTO dto)
        {

            var Categoria = await _repository.GetByIdAsync(dto.IdCategoria);

            if (Categoria == null || Categoria.Borrado)
                return OperationResult<CategoriumDTO>.Failure("No se encontraron los datos a actualizar");

            Categoria.Descripcion = dto.Descripcion;
            Categoria.IdServicio = dto.IdServicio;
            Categoria.UsuarioActualizacion = dto.UsuarioActualizacion;
            Categoria.FechaActualizacion = DateTime.Now;

            await _repository.UpdateAsync(Categoria);

            var resultDto = new CategoriumDTO
            {
                IdCategoria = Categoria.IdCategoria,
                Descripcion = Categoria.Descripcion,
                IdServicio = Categoria.IdServicio,
                Estado = Categoria.Estado,
                UsuarioCreacion = Categoria.UsuarioCreacion,
                FechaCreacion = Categoria.FechaCreacion,
                UsuarioEliminacion = Categoria.UsuarioEliminacion,
                FechaEliminado = Categoria.FechaEliminado,
                UsuarioActualizacion = Categoria.UsuarioActualizacion,
                FechaActualizacion = Categoria.FechaActualizacion,
                Borrado = Categoria.Borrado
            };

            return OperationResult<CategoriumDTO>.Succes("Datos actualizados correctamente", resultDto);
        }
    }
}
