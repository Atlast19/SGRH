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

        public Task<OperationResult<TarifaDTO>> DeleteAsync(int Id, int IdUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<IEnumerable<TarifaDTO>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<TarifaDTO>> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<TarifaDTO>> UpdateAsync(TarifaDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
