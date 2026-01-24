using SGRH.Application.DTOs.Habitacion.HabitacionDto;
using SGRH.Application.Interfaces.habitacion;
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

        public async Task<CreateHabitacionDto> CreateAsync(CreateHabitacionDto dto)
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

            await _repository.CreateAsync(Habitacion);

            var resultDto = new CreateHabitacionDto 
            {
                Numero = Habitacion.Numero,
                Detalle = Habitacion.Detalle,
                Precio = Habitacion.Precio,
                IdEstadoHabitacion = Habitacion.IdEstadoHabitacion,
                IdPiso = Habitacion.IdPiso,
                IdCategoria = Habitacion.IdCategoria,
                Estado = Habitacion.Estado,
                UsuarioCreacion = Habitacion.UsuarioCreacion,
                FechaCreacion = Habitacion.FechaCreacion
            };

            return resultDto;
        }

        public async Task<DeleteHabitacionDto> DeleteAsync(int Id, int IdUsuario)
        {
            var Habitacion = await _repository.GetByIdAsync(Id);

            Habitacion.Borrado = true;
            Habitacion.Estado = false;
            Habitacion.UsuarioEliminacion = IdUsuario;
            Habitacion.FechaEliminado = DateTime.Now;

            await _repository.UpdateAsync(Habitacion);

            var resultDto = new DeleteHabitacionDto
            {
                IdHabitacion = Habitacion.IdHabitacion,
                Estado = Habitacion.Estado,
                UsuarioEliminacion = Habitacion.UsuarioEliminacion,
                FechaEliminado = Habitacion.FechaEliminado,
                Borrado = Habitacion.Borrado
            };

            return resultDto;
        }

        public async Task<IEnumerable<ReadHabitacionDto>> GetAllAsync()
        {
            var Habitacion = await _repository.GetAllAsync();


            var dto = Habitacion.Where(c => !c.Borrado)
                .Select(c => new ReadHabitacionDto 
                {
                    IdHabitacion = c.IdHabitacion,
                    Numero = c.Numero,
                    Detalle = c.Detalle,
                    Precio = c.Precio,
                    IdEstadoHabitacion = c.IdEstadoHabitacion,
                    IdPiso = c.IdPiso,
                    IdCategoria = c.IdCategoria
                });

            return dto;
        }

        public async Task<ReadHabitacionDto> GetByIdAsync(int Id)
        {
            var Habitacion = await _repository.GetByIdAsync(Id);

            var resultDto = new ReadHabitacionDto
            {
                IdHabitacion = Habitacion.IdHabitacion,
                Numero = Habitacion.Numero,
                Detalle = Habitacion.Detalle,
                Precio = Habitacion.Precio,
                IdEstadoHabitacion = Habitacion.IdEstadoHabitacion,
                IdPiso = Habitacion.IdPiso,
                IdCategoria = Habitacion.IdCategoria
            };

            return resultDto;
        }

        public async Task<UpdateHabitacionDto> UpdateAsync(UpdateHabitacionDto dto)
        {

            var Habitacion = await _repository.GetByIdAsync(dto.IdHabitacion);

            Habitacion.Numero = dto.Numero;
            Habitacion.Detalle = dto.Detalle;
            Habitacion.Precio = dto.Precio;
            Habitacion.IdEstadoHabitacion = dto.IdEstadoHabitacion;
            Habitacion.IdPiso = dto.IdPiso;
            Habitacion.IdCategoria = dto.IdCategoria;


            Habitacion.UsuarioActualizacion = dto.UsuarioActualizacion;
            Habitacion.FechaActualizacion = DateTime.Now;

            var resultDto = new UpdateHabitacionDto
            {
                IdHabitacion = Habitacion.IdHabitacion,
                Numero = Habitacion.Numero,
                Detalle = Habitacion.Detalle,
                Precio = Habitacion.Precio,
                IdEstadoHabitacion = Habitacion.IdEstadoHabitacion,
                IdPiso = Habitacion.IdPiso,
                IdCategoria = Habitacion.IdCategoria,
                UsuarioActualizacion = Habitacion.UsuarioActualizacion,
                FechaActualizacion = Habitacion.FechaActualizacion
            };

            return resultDto;
        }
    }
}
