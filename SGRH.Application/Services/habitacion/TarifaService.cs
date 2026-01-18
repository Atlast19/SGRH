using SGRH.Application.DTOs.Habitacion;
using SGRH.Application.Interfaces.habitacion;
using SGRH.Domein.Base;
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

        public async Task<OperationResult<TarifaDTO>> CreateAsync(TarifaDTO dto)
        {
            var Tarifa = new Tarifa();

            Tarifa.IdHabitacion = dto.IdHabitacion;
            Tarifa.FechaInicio = dto.FechaInicio;
            Tarifa.FechaFin = dto.FechaFin;
            Tarifa.PrecioPorNoche = dto.PrecioPorNoche;
            Tarifa.Descuento = dto.Descuento;
            Tarifa.Descripcion = dto.Descripcion;
            Tarifa.Estado = true;
            Tarifa.Borrado = false;
            Tarifa.UsuarioCreacion = dto.UsuarioCreacion;
            Tarifa.FechaCreacion = DateTime.Now;

            await _repository.CreateAsync(Tarifa);

            var restulDto = new TarifaDTO
            {
                IdTarifa = Tarifa.IdTarifa,
                IdHabitacion = Tarifa.IdHabitacion,
                FechaInicio = Tarifa.FechaInicio,
                FechaFin = Tarifa.FechaFin,
                PrecioPorNoche = Tarifa.PrecioPorNoche,
                Descuento = Tarifa.Descuento,
                Descripcion = Tarifa.Descripcion,
                Estado = Tarifa.Estado,
                UsuarioCreacion = Tarifa.UsuarioCreacion,
                FechaCreacion = Tarifa.FechaCreacion,
                UsuarioEliminacion = Tarifa.UsuarioEliminacion,
                FechaEliminado = Tarifa.FechaEliminado,
                UsuarioActualizacion = Tarifa.UsuarioActualizacion,
                FechaActualizacion = Tarifa.FechaActualizacion,
                Borrado = Tarifa.Borrado
            };

            return OperationResult<TarifaDTO>.Succes("Datos agregados correctmanete", restulDto);

        }

        public async Task<OperationResult<TarifaDTO>> DeleteAsync(int Id, int IdUsuario)
        {
            var Tarifa = await _repository.GetByIdAsync(Id);

            if (Tarifa == null || Tarifa.Borrado)
                return OperationResult<TarifaDTO>.Failure("No se encontraron los datos a eliminar");

            Tarifa.Borrado = true;
            Tarifa.Estado = false;
            Tarifa.UsuarioEliminacion = IdUsuario;
            Tarifa.FechaEliminado = DateTime.Now;

            await _repository.UpdateAsync(Tarifa);

            var restulDto = new TarifaDTO
            {
                IdTarifa = Tarifa.IdTarifa,
                IdHabitacion = Tarifa.IdHabitacion,
                FechaInicio = Tarifa.FechaInicio,
                FechaFin = Tarifa.FechaFin,
                PrecioPorNoche = Tarifa.PrecioPorNoche,
                Descuento = Tarifa.Descuento,
                Descripcion = Tarifa.Descripcion,
                Estado = Tarifa.Estado,
                UsuarioCreacion = Tarifa.UsuarioCreacion,
                FechaCreacion = Tarifa.FechaCreacion,
                UsuarioEliminacion = Tarifa.UsuarioEliminacion,
                FechaEliminado = Tarifa.FechaEliminado,
                UsuarioActualizacion = Tarifa.UsuarioActualizacion,
                FechaActualizacion = Tarifa.FechaActualizacion,
                Borrado = Tarifa.Borrado
            };

            return OperationResult<TarifaDTO>.Succes("Datos eliminados correctmanete", restulDto);
        }

        public async Task<OperationResult<IEnumerable<TarifaDTO>>> GetAllAsync()
        {
            var Tarifa = await _repository.GetAllAsync();

            if (!Tarifa.Any())
                return OperationResult<IEnumerable<TarifaDTO>>.Failure("No se encontraron los datos");

            var dto = Tarifa.Where(c => !c.Borrado)
                .Select(c => new TarifaDTO
                {
                    IdTarifa = c.IdTarifa,
                    IdHabitacion = c.IdHabitacion,
                    FechaInicio = c.FechaInicio,
                    FechaFin = c.FechaFin,
                    PrecioPorNoche = c.PrecioPorNoche,
                    Descuento = c.Descuento,
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

            return OperationResult<IEnumerable<TarifaDTO>>.Succes("Datos cargados correctamente",dto);
        }

        public async Task<OperationResult<TarifaDTO>> GetByIdAsync(int Id)
        {
            var Tarifa = await _repository.GetByIdAsync(Id);

            if (Tarifa == null || Tarifa.Borrado)
                return OperationResult<TarifaDTO>.Failure("No se encontraron los datos solicitados");

            var restulDto = new TarifaDTO
            {
                IdTarifa = Tarifa.IdTarifa,
                IdHabitacion = Tarifa.IdHabitacion,
                FechaInicio = Tarifa.FechaInicio,
                FechaFin = Tarifa.FechaFin,
                PrecioPorNoche = Tarifa.PrecioPorNoche,
                Descuento = Tarifa.Descuento,
                Descripcion = Tarifa.Descripcion,
                Estado = Tarifa.Estado,
                UsuarioCreacion = Tarifa.UsuarioCreacion,
                FechaCreacion = Tarifa.FechaCreacion,
                UsuarioEliminacion = Tarifa.UsuarioEliminacion,
                FechaEliminado = Tarifa.FechaEliminado,
                UsuarioActualizacion = Tarifa.UsuarioActualizacion,
                FechaActualizacion = Tarifa.FechaActualizacion,
                Borrado = Tarifa.Borrado
            };

            return OperationResult<TarifaDTO>.Succes("Datos cargados correctmanete", restulDto);
        }

        public async Task<OperationResult<TarifaDTO>> UpdateAsync(TarifaDTO dto)
        {
            if (dto.Borrado)
                return OperationResult<TarifaDTO>.Failure("No se encontraron los datos a eliminar");

            var Tarifa = new Tarifa();


            Tarifa.IdHabitacion = dto.IdHabitacion;
            Tarifa.FechaInicio = dto.FechaInicio;
            Tarifa.FechaFin = dto.FechaFin;
            Tarifa.PrecioPorNoche = dto.PrecioPorNoche;
            Tarifa.Descuento = dto.Descuento;
            Tarifa.Descripcion = dto.Descripcion;

            Tarifa.UsuarioActualizacion = dto.UsuarioActualizacion;
            Tarifa.FechaActualizacion = DateTime.Now;

            await _repository.UpdateAsync(Tarifa);

            var restulDto = new TarifaDTO
            {
                IdTarifa = Tarifa.IdTarifa,
                IdHabitacion = Tarifa.IdHabitacion,
                FechaInicio = Tarifa.FechaInicio,
                FechaFin = Tarifa.FechaFin,
                PrecioPorNoche = Tarifa.PrecioPorNoche,
                Descuento = Tarifa.Descuento,
                Descripcion = Tarifa.Descripcion,
                Estado = Tarifa.Estado,
                UsuarioCreacion = Tarifa.UsuarioCreacion,
                FechaCreacion = Tarifa.FechaCreacion,
                UsuarioEliminacion = Tarifa.UsuarioEliminacion,
                FechaEliminado = Tarifa.FechaEliminado,
                UsuarioActualizacion = Tarifa.UsuarioActualizacion,
                FechaActualizacion = Tarifa.FechaActualizacion,
                Borrado = Tarifa.Borrado
            };

            return OperationResult<TarifaDTO>.Succes("Datos actualizados correctmanete", restulDto);
        }
    }
}
