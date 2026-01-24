using SGRH.Application.DTOs.Habitacion.EstadoHabitacionDto;
using SGRH.Application.Interfaces.habitacion;
using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Habitaciones;

namespace SGRH.Application.Services.habitacion
{
    public class EstadoHabitacionService : IEstadoHabitacionService
    {
        private readonly IEstadoHabitacionRepository _repository;

        public EstadoHabitacionService(IEstadoHabitacionRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateEstadoHabitacionDto> CreateAsync(CreateEstadoHabitacionDto dto)
        {
            var EstadoHabitacion = new EstadoHabitacion();

            EstadoHabitacion.Descripcion = dto.Descripcion;
            EstadoHabitacion.UsuarioCreacion = dto.UsuarioCreacion;
            EstadoHabitacion.FechaCreacion = DateTime.Now;
            EstadoHabitacion.Estado = true;

            await _repository.CreateAsync(EstadoHabitacion);

            var resultDto = new CreateEstadoHabitacionDto 
            {
                Descripcion = EstadoHabitacion.Descripcion,
                Estado = EstadoHabitacion.Estado,
                UsuarioCreacion = EstadoHabitacion.UsuarioCreacion,
                FechaCreacion = EstadoHabitacion.FechaCreacion
            };

            return resultDto;
        }

        public async Task<DeleteEstadoHabitacionDto> DeleteAsync(int Id, int IdUsuario)
        {
            var EstadoHabitacion = await _repository.GetByIdAsync(Id);

            EstadoHabitacion.Borrado = true;
            EstadoHabitacion.Estado = false;
            EstadoHabitacion.UsuarioEliminacion = IdUsuario;
            EstadoHabitacion.FechaEliminado = DateTime.Now;

            await _repository.UpdateAsync(EstadoHabitacion);

            var resultDto = new DeleteEstadoHabitacionDto
            {
                IdEstadoHabitacion = EstadoHabitacion.IdEstadoHabitacion,
                Estado = EstadoHabitacion.Estado,
                UsuarioEliminacion = EstadoHabitacion.UsuarioEliminacion,
                FechaEliminado = EstadoHabitacion.FechaEliminado,
                Borrado = EstadoHabitacion.Borrado
            };

            return resultDto;
        }

        public async Task<IEnumerable<ReadEstadoHabitacionDto>> GetAllAsync()
        {
            var EstadoHabitacion = await _repository.GetAllAsync();

            var dto = EstadoHabitacion.Where(c => !c.Borrado)
                .Select(c => new ReadEstadoHabitacionDto 
                {
                    IdEstadoHabitacion = c.IdEstadoHabitacion,
                    Descripcion = c.Descripcion
                });

            return dto;
        }

        public async Task<ReadEstadoHabitacionDto> GetByIdAsync(int Id)
        {
            var EstadoHabitacion = await _repository.GetByIdAsync(Id);

            var resultDto = new ReadEstadoHabitacionDto
            {
                IdEstadoHabitacion = EstadoHabitacion.IdEstadoHabitacion,
                Descripcion = EstadoHabitacion.Descripcion
            };

            return resultDto;
        }

        public async Task<UpdateEstadoHabitacionDto> UpdateAsync(UpdateEstadoHabitacionDto dto)
        {

            var EstadoHabitacion = await _repository.GetByIdAsync(dto.IdEstadoHabitacion);


            EstadoHabitacion.Descripcion = dto.Descripcion;
            EstadoHabitacion.UsuarioActualizacion = dto.UsuarioActualizacion;
            EstadoHabitacion.FechaActualizacion = DateTime.Now;

            var resultDto = new UpdateEstadoHabitacionDto
            {
                IdEstadoHabitacion = EstadoHabitacion.IdEstadoHabitacion,
                Descripcion = EstadoHabitacion.Descripcion,
                UsuarioActualizacion = EstadoHabitacion.UsuarioActualizacion,
                FechaActualizacion = EstadoHabitacion.FechaActualizacion
            };

            return resultDto;

        }
    }
}
