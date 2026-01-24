using SGRH.Application.DTOs.Habitacion.CategoriumDto;
using SGRH.Application.Interfaces.habitacion;
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

        public async Task<CreateCategoriumDto> CreateAsync(CreateCategoriumDto dto)
        {
            var Categoria = new Categorium();

            Categoria.Descripcion = dto.Descripcion;
            Categoria.IdServicio = dto.IdServicio;
            Categoria.Estado = true;
            Categoria.UsuarioCreacion = dto.UsuarioCreacion;
            Categoria.FechaCreacion = DateTime.Now;

            await _repository.CreateAsync(Categoria);

            var resultDto = new CreateCategoriumDto
            {
                Descripcion = Categoria.Descripcion,
                IdServicio = Categoria.IdServicio,
                Estado = Categoria.Estado,
                UsuarioCreacion = Categoria.UsuarioCreacion,
                FechaCreacion = Categoria.FechaCreacion
            };

            return resultDto;
        }

        public async Task<DeleteCategoriumDto> DeleteAsync(int Id, int IdUsuario)
        {
            var Categoria = await _repository.GetByIdAsync(Id);

            Categoria.Borrado = true;
            Categoria.Estado = false;
            Categoria.UsuarioEliminacion = IdUsuario;
            Categoria.FechaEliminado = DateTime.Now;

            await _repository.UpdateAsync(Categoria);

            var resultDto = new DeleteCategoriumDto
            {
                IdCategoria = Categoria.IdCategoria,
                Estado = Categoria.Estado,
                UsuarioEliminacion = Categoria.UsuarioEliminacion,
                FechaEliminado = Categoria.FechaEliminado,
                Borrado = Categoria.Borrado
            };

            return resultDto;
        }

        public async Task<IEnumerable<ReadCategoriumDto>> GetAllAsync()
        {
            var Categoria = await _repository.GetAllAsync();

            var dto = Categoria.Where(c => !c.Borrado)
                .Select(c => new ReadCategoriumDto 
                {
                    IdCategoria = c.IdCategoria,
                    Descripcion = c.Descripcion,
                    IdServicio = c.IdServicio
                });

            return dto;
        }

        public async Task<ReadCategoriumDto> GetByIdAsync(int Id)
        {
            var Categoria = await _repository.GetByIdAsync(Id);

            var resultDto = new ReadCategoriumDto
            {
                IdCategoria = Categoria.IdCategoria,
                Descripcion = Categoria.Descripcion,
                IdServicio = Categoria.IdServicio
            };

            return resultDto;
        }

        public async Task<UpdateCategoriumDto> UpdateAsync(UpdateCategoriumDto dto)
        {

            var Categoria = await _repository.GetByIdAsync(dto.IdCategoria);

            Categoria.Descripcion = dto.Descripcion;
            Categoria.IdServicio = dto.IdServicio;
            Categoria.UsuarioActualizacion = dto.UsuarioActualizacion;
            Categoria.FechaActualizacion = DateTime.Now;

            await _repository.UpdateAsync(Categoria);

            var resultDto = new UpdateCategoriumDto
            {
                IdCategoria = Categoria.IdCategoria,
                Descripcion = Categoria.Descripcion,
                IdServicio = Categoria.IdServicio,
                UsuarioActualizacion = Categoria.UsuarioActualizacion,
                FechaActualizacion = Categoria.FechaActualizacion
            };

            return resultDto;
        }
    }
}
