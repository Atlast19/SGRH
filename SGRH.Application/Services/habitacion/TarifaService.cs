using SGRH.Application.DTOs.Habitacion.TarifaDto;
using SGRH.Application.Interfaces.habitacion;
using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Habitaciones;

namespace SGRH.Application.Services.habitacion
{
    public class TarifaService : ITarifaService
    {
        private readonly ITarifaRepository _repository;

        public TarifaService(ITarifaRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateTarifaDto> CreateAsync(CreateTarifaDto dto)
        {
            var Tarifa = new Tarifa();

            Tarifa.IdHabitacion = dto.IdHabitacion;
            Tarifa.FechaInicio = dto.FechaInicio;
            Tarifa.FechaFin = dto.FechaFin;
            Tarifa.PrecioPorNoche = dto.PrecioPorNoche;
            Tarifa.Descuento = dto.Descuento;
            Tarifa.Descripcion = dto.Descripcion;
            Tarifa.Estado = true;
            Tarifa.UsuarioCreacion = dto.UsuarioCreacion;
            Tarifa.FechaCreacion = DateTime.Now;

            await _repository.CreateAsync(Tarifa);

            var restulDto = new CreateTarifaDto
            {
                IdHabitacion = Tarifa.IdHabitacion,
                FechaInicio = Tarifa.FechaInicio,
                FechaFin = Tarifa.FechaFin,
                PrecioPorNoche = Tarifa.PrecioPorNoche,
                Descuento = Tarifa.Descuento,
                Descripcion = Tarifa.Descripcion,
                UsuarioCreacion = Tarifa.UsuarioCreacion,
                FechaCreacion = Tarifa.FechaCreacion
            };

            return restulDto;

        }

        public async Task<DeleteTarifaDto> DeleteAsync(int Id, int IdUsuario)
        {
            var Tarifa = await _repository.GetByIdAsync(Id);

            Tarifa.Borrado = true;
            Tarifa.Estado = false;
            Tarifa.UsuarioEliminacion = IdUsuario;
            Tarifa.FechaEliminado = DateTime.Now;

            await _repository.UpdateAsync(Tarifa);

            var restulDto = new DeleteTarifaDto
            {
                IdTarifa = Tarifa.IdTarifa,
                Estado = Tarifa.Estado,
                UsuarioEliminacion = Tarifa.UsuarioEliminacion,
                FechaEliminado = Tarifa.FechaEliminado,
                Borrado = Tarifa.Borrado
            };

            return restulDto;
        }

        public async Task<IEnumerable<ReadTarifaDto>> GetAllAsync()
        {
            var Tarifa = await _repository.GetAllAsync();

            var dto = Tarifa.Where(c => !c.Borrado)
                .Select(c => new ReadTarifaDto
                {
                    IdTarifa = c.IdTarifa,
                    IdHabitacion = c.IdHabitacion,
                    FechaInicio = c.FechaInicio,
                    FechaFin = c.FechaFin,
                    PrecioPorNoche = c.PrecioPorNoche,
                    Descuento = c.Descuento,
                    Descripcion = c.Descripcion
                });

            return dto;
        }

        public async Task<ReadTarifaDto> GetByIdAsync(int Id)
        {
            var Tarifa = await _repository.GetByIdAsync(Id);

            var restulDto = new ReadTarifaDto
            {
                IdTarifa = Tarifa.IdTarifa,
                IdHabitacion = Tarifa.IdHabitacion,
                FechaInicio = Tarifa.FechaInicio,
                FechaFin = Tarifa.FechaFin,
                PrecioPorNoche = Tarifa.PrecioPorNoche,
                Descuento = Tarifa.Descuento,
                Descripcion = Tarifa.Descripcion
            };

            return restulDto;
        }

        public async Task<UpdateTarifaDto> UpdateAsync(UpdateTarifaDto dto)
        {

           var Tarifa =  await _repository.GetByIdAsync(dto.IdTarifa);


            Tarifa.IdHabitacion = dto.IdHabitacion;
            Tarifa.FechaInicio = dto.FechaInicio;
            Tarifa.FechaFin = dto.FechaFin;
            Tarifa.PrecioPorNoche = dto.PrecioPorNoche;
            Tarifa.Descuento = dto.Descuento;
            Tarifa.Descripcion = dto.Descripcion;

            Tarifa.UsuarioActualizacion = dto.UsuarioActualizacion;
            Tarifa.FechaActualizacion = DateTime.Now;

            await _repository.UpdateAsync(Tarifa);

            var restulDto = new UpdateTarifaDto
            {
                IdTarifa = Tarifa.IdTarifa,
                IdHabitacion = Tarifa.IdHabitacion,
                FechaInicio = Tarifa.FechaInicio,
                FechaFin = Tarifa.FechaFin,
                PrecioPorNoche = Tarifa.PrecioPorNoche,
                Descuento = Tarifa.Descuento,
                Descripcion = Tarifa.Descripcion,
                UsuarioActualizacion = Tarifa.UsuarioActualizacion,
                FechaActualizacion = Tarifa.FechaActualizacion
            };

            return restulDto;
        }
    }
}
