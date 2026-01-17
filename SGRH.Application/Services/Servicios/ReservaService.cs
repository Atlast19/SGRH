

using SGRH.Application.DTOs.Reserva;
using SGRH.Application.Interfaces.Services;
using SGRH.Domein.Base;
using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Servicios;

namespace SGRH.Application.Services.Servicios
{
    public class ReservaService : IReservaServices
    {
        private readonly IReservaRepository _repository;

        public ReservaService(IReservaRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult<ReservaDTO>> CreateAsync(ReservaDTO dto)
        {
            var Reserva = new Reserva();

            Reserva.IdCliente = dto.IdCliente;
            Reserva.IdHabitacion = dto.IdHabitacion;
            Reserva.FechaEntrada = dto.FechaEntrada;
            Reserva.FechaSalida = dto.FechaSalida;
            Reserva.FechaSalidaConfirmacion = dto.FechaSalidaConfirmacion;
            Reserva.PrecioInicial = dto.PrecioInicial;
            Reserva.Adelanto = dto.Adelanto;
            Reserva.PrecioRestante = dto.PrecioRestante;
            Reserva.TotalPagado = dto.TotalPagado;
            Reserva.CostoPenalidad = dto.CostoPenalidad;
            Reserva.Observacion = dto.Observacion;
            Reserva.Estado = true;
            Reserva.UsuarioCreacion = dto.UsuarioCreacion;
            Reserva.FechaCreacion = DateTime.Now;
            Reserva.Borrado = false;

            await _repository.CreateAsync(Reserva);

            var resultDto = new ReservaDTO
            {
                IdReserva = Reserva.IdReserva,
                IdCliente = Reserva.IdCliente,
                IdHabitacion = Reserva.IdHabitacion,
                FechaEntrada = Reserva.FechaEntrada,
                FechaSalida = Reserva.FechaSalida,
                FechaSalidaConfirmacion = Reserva.FechaSalidaConfirmacion,
                PrecioInicial = Reserva.PrecioInicial,
                Adelanto = Reserva.Adelanto,
                PrecioRestante = Reserva.PrecioRestante,
                TotalPagado = Reserva.TotalPagado,
                CostoPenalidad = Reserva.CostoPenalidad,
                Observacion = Reserva.Observacion,
                Estado = Reserva.Estado,
                UsuarioCreacion = Reserva.UsuarioCreacion,
                FechaCreacion = Reserva.FechaCreacion,
                UsuarioEliminacion = Reserva.UsuarioEliminacion,
                FechaEliminado = Reserva.FechaEliminado,
                UsuarioActualizacion = Reserva.UsuarioActualizacion,
                FechaActualizacion = Reserva.FechaActualizacion,
                Borrado = Reserva.Borrado
            };

            return OperationResult<ReservaDTO>.Succes("Datos agregados correctamente",resultDto);
        }

        public async Task<OperationResult<ReservaDTO>> DeleteAsync(int Id, int IdUsuario)
        {
            var Reserva = await _repository.GetByIdAsync(Id);

            if (Reserva == null || Reserva.Borrado)
                return OperationResult<ReservaDTO>.Failure("No se encontraron los datos a eliminar");

            Reserva.Borrado = true;
            Reserva.Estado = false;
            Reserva.UsuarioEliminacion = IdUsuario;
            Reserva.FechaEliminado = DateTime.Now;

            await _repository.UpdateAsync(Reserva);

            var resultDto = new ReservaDTO
            {
                IdReserva = Reserva.IdReserva,
                IdCliente = Reserva.IdCliente,
                IdHabitacion = Reserva.IdHabitacion,
                FechaEntrada = Reserva.FechaEntrada,
                FechaSalida = Reserva.FechaSalida,
                FechaSalidaConfirmacion = Reserva.FechaSalidaConfirmacion,
                PrecioInicial = Reserva.PrecioInicial,
                Adelanto = Reserva.Adelanto,
                PrecioRestante = Reserva.PrecioRestante,
                TotalPagado = Reserva.TotalPagado,
                CostoPenalidad = Reserva.CostoPenalidad,
                Observacion = Reserva.Observacion,
                Estado = Reserva.Estado,
                UsuarioCreacion = Reserva.UsuarioCreacion,
                FechaCreacion = Reserva.FechaCreacion,
                UsuarioEliminacion = Reserva.UsuarioEliminacion,
                FechaEliminado = Reserva.FechaEliminado,
                UsuarioActualizacion = Reserva.UsuarioActualizacion,
                FechaActualizacion = Reserva.FechaActualizacion,
                Borrado = Reserva.Borrado
            };

            return OperationResult<ReservaDTO>.Succes("Datos eliminados correctamente", resultDto);
        }

        public async Task<OperationResult<IEnumerable<ReservaDTO>>> GetAllAsync()
        {
            var Reserva = await _repository.GetAllAsync();

            if (!Reserva.Any())
                return OperationResult<IEnumerable<ReservaDTO>>.Failure("No se encontraron los datos");

            var dto = Reserva.Where(c => !c.Borrado)
                .Select(c => new ReservaDTO 
                {
                    IdReserva = c.IdReserva,
                    IdCliente = c.IdCliente,
                    IdHabitacion = c.IdHabitacion,
                    FechaEntrada = c.FechaEntrada,
                    FechaSalida = c.FechaSalida,
                    FechaSalidaConfirmacion = c.FechaSalidaConfirmacion,
                    PrecioInicial = c.PrecioInicial,
                    Adelanto = c.Adelanto,
                    PrecioRestante = c.PrecioRestante,
                    TotalPagado = c.TotalPagado,
                    CostoPenalidad = c.CostoPenalidad,
                    Observacion = c.Observacion,
                    Estado = c.Estado,
                    UsuarioCreacion = c.UsuarioCreacion,
                    FechaCreacion = c.FechaCreacion,
                    UsuarioEliminacion = c.UsuarioEliminacion,
                    FechaEliminado = c.FechaEliminado,
                    UsuarioActualizacion = c.UsuarioActualizacion,
                    FechaActualizacion = c.FechaActualizacion,
                    Borrado = c.Borrado
                });

            return OperationResult<IEnumerable<ReservaDTO>>.Succes("Datos cargados correctamente",dto);
        }

        public async Task<OperationResult<ReservaDTO>> GetByIdAsync(int Id)
        {
            var Reserva = await _repository.GetByIdAsync(Id);

            if (Reserva == null || Reserva.Borrado)
                return OperationResult<ReservaDTO>.Failure("No se encontraron los datos solicitados");

            var resultDto = new ReservaDTO
            {
                IdReserva = Reserva.IdReserva,
                IdCliente = Reserva.IdCliente,
                IdHabitacion = Reserva.IdHabitacion,
                FechaEntrada = Reserva.FechaEntrada,
                FechaSalida = Reserva.FechaSalida,
                FechaSalidaConfirmacion = Reserva.FechaSalidaConfirmacion,
                PrecioInicial = Reserva.PrecioInicial,
                Adelanto = Reserva.Adelanto,
                PrecioRestante = Reserva.PrecioRestante,
                TotalPagado = Reserva.TotalPagado,
                CostoPenalidad = Reserva.CostoPenalidad,
                Observacion = Reserva.Observacion,
                Estado = Reserva.Estado,
                UsuarioCreacion = Reserva.UsuarioCreacion,
                FechaCreacion = Reserva.FechaCreacion,
                UsuarioEliminacion = Reserva.UsuarioEliminacion,
                FechaEliminado = Reserva.FechaEliminado,
                UsuarioActualizacion = Reserva.UsuarioActualizacion,
                FechaActualizacion = Reserva.FechaActualizacion,
                Borrado = Reserva.Borrado
            };

            return OperationResult<ReservaDTO>.Succes("Datos cargados correctamente", resultDto);
        }

        public async Task<OperationResult<ReservaDTO>> UpdateAsync(ReservaDTO dto)
        {
            if (dto.Borrado)
                return OperationResult<ReservaDTO>.Failure("No se encontraro nlos datos a actualizar");

            var Reserva = new Reserva();

            Reserva.IdCliente = dto.IdCliente;
            Reserva.IdHabitacion = dto.IdHabitacion;
            Reserva.FechaEntrada = dto.FechaEntrada;
            Reserva.FechaSalida = dto.FechaSalida;
            Reserva.FechaSalidaConfirmacion = dto.FechaSalidaConfirmacion;
            Reserva.PrecioInicial = dto.PrecioInicial;
            Reserva.Adelanto = dto.Adelanto;
            Reserva.PrecioRestante = dto.PrecioRestante;
            Reserva.TotalPagado = dto.TotalPagado;
            Reserva.CostoPenalidad = dto.CostoPenalidad;
            Reserva.Observacion = dto.Observacion;

            Reserva.UsuarioActualizacion = dto.UsuarioActualizacion;
            Reserva.FechaActualizacion = DateTime.Now;

            await _repository.UpdateAsync(Reserva);


            var resultDto = new ReservaDTO
            {
                IdReserva = Reserva.IdReserva,
                IdCliente = Reserva.IdCliente,
                IdHabitacion = Reserva.IdHabitacion,
                FechaEntrada = Reserva.FechaEntrada,
                FechaSalida = Reserva.FechaSalida,
                FechaSalidaConfirmacion = Reserva.FechaSalidaConfirmacion,
                PrecioInicial = Reserva.PrecioInicial,
                Adelanto = Reserva.Adelanto,
                PrecioRestante = Reserva.PrecioRestante,
                TotalPagado = Reserva.TotalPagado,
                CostoPenalidad = Reserva.CostoPenalidad,
                Observacion = Reserva.Observacion,
                Estado = Reserva.Estado,
                UsuarioCreacion = Reserva.UsuarioCreacion,
                FechaCreacion = Reserva.FechaCreacion,
                UsuarioEliminacion = Reserva.UsuarioEliminacion,
                FechaEliminado = Reserva.FechaEliminado,
                UsuarioActualizacion = Reserva.UsuarioActualizacion,
                FechaActualizacion = Reserva.FechaActualizacion,
                Borrado = Reserva.Borrado
            };

            return OperationResult<ReservaDTO>.Succes("Datos actualizados correctamente", resultDto);

        }
    }
}
