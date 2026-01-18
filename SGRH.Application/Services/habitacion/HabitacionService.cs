using SGRH.Application.DTOs.Habitacion;
using SGRH.Application.Interfaces.habitacion;
using SGRH.Domein.Base;
using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Habitaciones;

namespace SGRH.Application.Services.habitacion
{
    public class HabitacionService : IHabitacionService
    {
        private readonly IHabitacionRepository _repository;

        public HabitacionService(IHabitacionRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult<HabitacionDTO>> CreateAsync(HabitacionDTO dto)
        {
            var Habitacion = new Habitacion();

            Habitacion.Numero = dto.Numero;
            Habitacion.Detalle = dto.Detalle;
            Habitacion.Precio = dto.Precio;
            Habitacion.IdEstadoHabitacion = dto.IdEstadoHabitacion;
            Habitacion.IdPiso = dto.IdPiso;
            Habitacion.IdCategoria = dto.IdCategoria;
            Habitacion.Estado = true;
            Habitacion.UsuarioCreacion = dto.UsuarioCreacion;
            Habitacion.FechaCreacion = DateTime.Now;
            Habitacion.Borrado = false;

            await _repository.CreateAsync(Habitacion);

            var resultDto = new HabitacionDTO 
            {
                IdHabitacion = Habitacion.IdHabitacion,
                Numero = Habitacion.Numero,
                Detalle = Habitacion.Detalle,
                Precio = Habitacion.Precio,
                IdEstadoHabitacion = Habitacion.IdEstadoHabitacion,
                IdPiso = Habitacion.IdPiso,
                IdCategoria = Habitacion.IdCategoria,
                Estado = Habitacion.Estado,
                UsuarioCreacion = Habitacion.UsuarioCreacion,
                FechaCreacion = Habitacion.FechaCreacion,
                UsuarioEliminacion = Habitacion.UsuarioEliminacion,
                FechaEliminado = Habitacion.FechaEliminado,
                UsuarioActualizacion = Habitacion.UsuarioActualizacion,
                FechaActualizacion = Habitacion.FechaActualizacion,
                Borrado = Habitacion.Borrado
            };

            return OperationResult<HabitacionDTO>.Succes("Datos agregados correctamente",resultDto);
        }

        public async Task<OperationResult<HabitacionDTO>> DeleteAsync(int Id, int IdUsuario)
        {
            var Habitacion = await _repository.GetByIdAsync(Id);

            if (Habitacion == null || Habitacion.Borrado)
                return OperationResult<HabitacionDTO>.Failure("No se encontraron los datos a eliminar");

            Habitacion.Borrado = true;
            Habitacion.Estado = false;
            Habitacion.UsuarioEliminacion = IdUsuario;
            Habitacion.FechaEliminado = DateTime.Now;

            await _repository.UpdateAsync(Habitacion);

            var resultDto = new HabitacionDTO
            {
                IdHabitacion = Habitacion.IdHabitacion,
                Numero = Habitacion.Numero,
                Detalle = Habitacion.Detalle,
                Precio = Habitacion.Precio,
                IdEstadoHabitacion = Habitacion.IdEstadoHabitacion,
                IdPiso = Habitacion.IdPiso,
                IdCategoria = Habitacion.IdCategoria,
                Estado = Habitacion.Estado,
                UsuarioCreacion = Habitacion.UsuarioCreacion,
                FechaCreacion = Habitacion.FechaCreacion,
                UsuarioEliminacion = Habitacion.UsuarioEliminacion,
                FechaEliminado = Habitacion.FechaEliminado,
                UsuarioActualizacion = Habitacion.UsuarioActualizacion,
                FechaActualizacion = Habitacion.FechaActualizacion,
                Borrado = Habitacion.Borrado
            };

            return OperationResult<HabitacionDTO>.Succes("Datos agregados correctamente", resultDto);
        }

        public async Task<OperationResult<IEnumerable<HabitacionDTO>>> GetAllAsync()
        {
            var Habitacion = await _repository.GetAllAsync();

            if (!Habitacion.Any())
                return OperationResult<IEnumerable<HabitacionDTO>>.Failure("No se encontraron los datos");


            var dto = Habitacion.Where(c => !c.Borrado)
                .Select(c => new HabitacionDTO 
                {
                    IdHabitacion = c.IdHabitacion,
                    Numero = c.Numero,
                    Detalle = c.Detalle,
                    Precio = c.Precio,
                    IdEstadoHabitacion = c.IdEstadoHabitacion,
                    IdPiso = c.IdPiso,
                    IdCategoria = c.IdCategoria,
                    Estado = c.Estado,
                    UsuarioCreacion = c.UsuarioCreacion,
                    FechaCreacion = c.FechaCreacion,
                    UsuarioEliminacion = c.UsuarioEliminacion,
                    FechaEliminado = c.FechaEliminado,
                    UsuarioActualizacion = c.UsuarioActualizacion,
                    FechaActualizacion = c.FechaActualizacion,
                    Borrado = c.Borrado
                });

            return OperationResult<IEnumerable<HabitacionDTO>>.Succes("Datos cargados correctamente",dto);

        }

        public async Task<OperationResult<HabitacionDTO>> GetByIdAsync(int Id)
        {
            var Habitacion = await _repository.GetByIdAsync(Id);

            if (Habitacion == null || Habitacion.Borrado)
                return OperationResult<HabitacionDTO>.Failure("No se encontraron los datos solicitados");

            var resultDto = new HabitacionDTO
            {
                IdHabitacion = Habitacion.IdHabitacion,
                Numero = Habitacion.Numero,
                Detalle = Habitacion.Detalle,
                Precio = Habitacion.Precio,
                IdEstadoHabitacion = Habitacion.IdEstadoHabitacion,
                IdPiso = Habitacion.IdPiso,
                IdCategoria = Habitacion.IdCategoria,
                Estado = Habitacion.Estado,
                UsuarioCreacion = Habitacion.UsuarioCreacion,
                FechaCreacion = Habitacion.FechaCreacion,
                UsuarioEliminacion = Habitacion.UsuarioEliminacion,
                FechaEliminado = Habitacion.FechaEliminado,
                UsuarioActualizacion = Habitacion.UsuarioActualizacion,
                FechaActualizacion = Habitacion.FechaActualizacion,
                Borrado = Habitacion.Borrado
            };

            return OperationResult<HabitacionDTO>.Succes("Datos cargados correctamente", resultDto);

        }

        public async Task<OperationResult<HabitacionDTO>> UpdateAsync(HabitacionDTO dto)
        {
            if (dto.Borrado)
                return OperationResult<HabitacionDTO>.Failure("No se encontraron los datos");

            var Habitacion = new Habitacion();

            Habitacion.Numero = dto.Numero;
            Habitacion.Detalle = dto.Detalle;
            Habitacion.Precio = dto.Precio;
            Habitacion.IdEstadoHabitacion = dto.IdEstadoHabitacion;
            Habitacion.IdPiso = dto.IdPiso;
            Habitacion.IdCategoria = dto.IdCategoria;


            Habitacion.UsuarioActualizacion = dto.UsuarioActualizacion;
            Habitacion.FechaActualizacion = DateTime.Now;

            var resultDto = new HabitacionDTO
            {
                IdHabitacion = Habitacion.IdHabitacion,
                Numero = Habitacion.Numero,
                Detalle = Habitacion.Detalle,
                Precio = Habitacion.Precio,
                IdEstadoHabitacion = Habitacion.IdEstadoHabitacion,
                IdPiso = Habitacion.IdPiso,
                IdCategoria = Habitacion.IdCategoria,
                Estado = Habitacion.Estado,
                UsuarioCreacion = Habitacion.UsuarioCreacion,
                FechaCreacion = Habitacion.FechaCreacion,
                UsuarioEliminacion = Habitacion.UsuarioEliminacion,
                FechaEliminado = Habitacion.FechaEliminado,
                UsuarioActualizacion = Habitacion.UsuarioActualizacion,
                FechaActualizacion = Habitacion.FechaActualizacion,
                Borrado = Habitacion.Borrado
            };

            return OperationResult<HabitacionDTO>.Succes("Datos actualizados correctamente", resultDto);

        }
    }
}
