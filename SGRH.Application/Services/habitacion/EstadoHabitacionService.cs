using SGRH.Application.DTOs.Habitacion;
using SGRH.Application.Interfaces.habitacion;
using SGRH.Domein.Base;
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

        public async Task<OperationResult<EstadoHabitacionDTO>> CreateAsync(EstadoHabitacionDTO dto)
        {
            var EstadoHabitacion = new EstadoHabitacion();

            EstadoHabitacion.Descripcion = dto.Descripcion;
            EstadoHabitacion.UsuarioCreacion = dto.UsuarioCreacion;
            EstadoHabitacion.FechaCreacion = DateTime.Now;
            EstadoHabitacion.Borrado = false;
            EstadoHabitacion.Estado = true;

            await _repository.CreateAsync(EstadoHabitacion);

            var resultDto = new EstadoHabitacionDTO 
            {
                IdEstadoHabitacion = EstadoHabitacion.IdEstadoHabitacion,
                Descripcion = EstadoHabitacion.Descripcion,
                Estado = EstadoHabitacion.Estado,
                UsuarioCreacion = EstadoHabitacion.UsuarioCreacion,
                FechaCreacion = EstadoHabitacion.FechaCreacion,
                UsuarioEliminacion = EstadoHabitacion.UsuarioEliminacion,
                FechaEliminado = EstadoHabitacion.FechaEliminado,
                UsuarioActualizacion = EstadoHabitacion.UsuarioActualizacion,
                FechaActualizacion = EstadoHabitacion.FechaActualizacion,
                Borrado = EstadoHabitacion.Borrado
            };

            return OperationResult<EstadoHabitacionDTO>.Succes("Datos agregados correctamente",resultDto);
        }

        public async Task<OperationResult<EstadoHabitacionDTO>> DeleteAsync(int Id, int IdUsuario)
        {
            var EstadoHabitacion = await _repository.GetByIdAsync(Id);

            if (EstadoHabitacion == null || EstadoHabitacion.Borrado)
                return OperationResult<EstadoHabitacionDTO>.Failure("No se encontraron los datos a elimianar");

            EstadoHabitacion.Borrado = true;
            EstadoHabitacion.Estado = false;
            EstadoHabitacion.UsuarioEliminacion = IdUsuario;
            EstadoHabitacion.FechaEliminado = DateTime.Now;

            await _repository.UpdateAsync(EstadoHabitacion);

            var resultDto = new EstadoHabitacionDTO
            {
                IdEstadoHabitacion = EstadoHabitacion.IdEstadoHabitacion,
                Descripcion = EstadoHabitacion.Descripcion,
                Estado = EstadoHabitacion.Estado,
                UsuarioCreacion = EstadoHabitacion.UsuarioCreacion,
                FechaCreacion = EstadoHabitacion.FechaCreacion,
                UsuarioEliminacion = EstadoHabitacion.UsuarioEliminacion,
                FechaEliminado = EstadoHabitacion.FechaEliminado,
                UsuarioActualizacion = EstadoHabitacion.UsuarioActualizacion,
                FechaActualizacion = EstadoHabitacion.FechaActualizacion,
                Borrado = EstadoHabitacion.Borrado
            };

            return OperationResult<EstadoHabitacionDTO>.Succes("Datos eliminados correctamente", resultDto);
        }

        public async Task<OperationResult<IEnumerable<EstadoHabitacionDTO>>> GetAllAsync()
        {
            var EstadoHabitacion = await _repository.GetAllAsync();

            if (!EstadoHabitacion.Any())
                return OperationResult<IEnumerable<EstadoHabitacionDTO>>.Failure("No se econtraron los datos");

            var dto = EstadoHabitacion.Where(c => !c.Borrado)
                .Select(c => new EstadoHabitacionDTO 
                {
                    IdEstadoHabitacion = c.IdEstadoHabitacion,
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

            return OperationResult<IEnumerable<EstadoHabitacionDTO>>.Succes("Datos cargados correctamente", dto);
        }

        public async Task<OperationResult<EstadoHabitacionDTO>> GetByIdAsync(int Id)
        {
            var EstadoHabitacion = await _repository.GetByIdAsync(Id);

            if (EstadoHabitacion == null || EstadoHabitacion.Borrado)
                return OperationResult<EstadoHabitacionDTO>.Failure("No se encontraron los datos");

            var resultDto = new EstadoHabitacionDTO
            {
                IdEstadoHabitacion = EstadoHabitacion.IdEstadoHabitacion,
                Descripcion = EstadoHabitacion.Descripcion,
                Estado = EstadoHabitacion.Estado,
                UsuarioCreacion = EstadoHabitacion.UsuarioCreacion,
                FechaCreacion = EstadoHabitacion.FechaCreacion,
                UsuarioEliminacion = EstadoHabitacion.UsuarioEliminacion,
                FechaEliminado = EstadoHabitacion.FechaEliminado,
                UsuarioActualizacion = EstadoHabitacion.UsuarioActualizacion,
                FechaActualizacion = EstadoHabitacion.FechaActualizacion,
                Borrado = EstadoHabitacion.Borrado
            };

            return OperationResult<EstadoHabitacionDTO>.Succes("Datos eliminados correctamente", resultDto);
        }

        public async Task<OperationResult<EstadoHabitacionDTO>> UpdateAsync(EstadoHabitacionDTO dto)
        {
            if (dto.Borrado)
                return OperationResult<EstadoHabitacionDTO>.Failure("No se encontraron los datos a actualizar");

            var EstadoHabitacion = new EstadoHabitacion();

            EstadoHabitacion.Descripcion = dto.Descripcion;
            EstadoHabitacion.UsuarioActualizacion = dto.UsuarioActualizacion;
            EstadoHabitacion.FechaActualizacion = DateTime.Now;

            var resultDto = new EstadoHabitacionDTO
            {
                IdEstadoHabitacion = EstadoHabitacion.IdEstadoHabitacion,
                Descripcion = EstadoHabitacion.Descripcion,
                Estado = EstadoHabitacion.Estado,
                UsuarioCreacion = EstadoHabitacion.UsuarioCreacion,
                FechaCreacion = EstadoHabitacion.FechaCreacion,
                UsuarioEliminacion = EstadoHabitacion.UsuarioEliminacion,
                FechaEliminado = EstadoHabitacion.FechaEliminado,
                UsuarioActualizacion = EstadoHabitacion.UsuarioActualizacion,
                FechaActualizacion = EstadoHabitacion.FechaActualizacion,
                Borrado = EstadoHabitacion.Borrado
            };

            return OperationResult<EstadoHabitacionDTO>.Succes("Datos actualizados correctamente", resultDto);

        }
    }
}
