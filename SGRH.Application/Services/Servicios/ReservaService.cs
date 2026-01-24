using SGRH.Application.DTOs.Reserva.ReservaDto;
using SGRH.Application.Interfaces.Services;
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

        public async Task<CreateReservaDto> CreateAsync(CreateReservaDto dto)
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

            await _repository.CreateAsync(Reserva);

            var resultDto = new CreateReservaDto
            {
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
                FechaCreacion = Reserva.FechaCreacion
            };

            return resultDto;
        }

        public async Task<DeleteReservaDto> DeleteAsync(int Id, int IdUsuario)
        {
            var Reserva = await _repository.GetByIdAsync(Id);

            Reserva.Borrado = true;
            Reserva.Estado = false;
            Reserva.UsuarioEliminacion = IdUsuario;
            Reserva.FechaEliminado = DateTime.Now;

            await _repository.UpdateAsync(Reserva);

            var resultDto = new DeleteReservaDto
            {
                IdReserva = Reserva.IdReserva,
                Estado = Reserva.Estado,
                UsuarioEliminacion = Reserva.UsuarioEliminacion,
                FechaEliminado = Reserva.FechaEliminado,
                Borrado = Reserva.Borrado
            };

            return resultDto;
        }

        public async Task<IEnumerable<ReadReservaDto>> GetAllAsync()
        {
            var Reserva = await _repository.GetAllAsync();


            var dto = Reserva.Where(c => !c.Borrado)
                .Select(c => new ReadReservaDto 
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
                    Observacion = c.Observacion
                });

            return dto;
        }

        public async Task<ReadReservaDto> GetByIdAsync(int Id)
        {
            var Reserva = await _repository.GetByIdAsync(Id);

            var resultDto = new ReadReservaDto
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
                Observacion = Reserva.Observacion
            };

            return resultDto;
        }

        public async Task<UpdateReservaDto> UpdateAsync(UpdateReservaDto dto)
        {

           var Reserva = await _repository.GetByIdAsync(dto.IdReserva);


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


            var resultDto = new UpdateReservaDto
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
                UsuarioActualizacion = Reserva.UsuarioActualizacion,
                FechaActualizacion = Reserva.FechaActualizacion
            };

            return resultDto;
        }
    }
}
