
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGRH.Domein.Base;
using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Servicios;
using SGRH.Domein.Models.Servicios;
using SGRH.Percistence.Context;

namespace SGRH.Percistence.Repository.Servicios
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly SGHRContext _context;
        private readonly ILogger<ReservaRepository> _logger;
        DbSet<Reserva> _dbSet;
        public ReservaRepository(SGHRContext context, ILogger<ReservaRepository> logger)
        {
            _context = context;
            _logger = logger;
            _dbSet = context.Set<Reserva>();
        }
        public async Task<OperationResult<ReservaModel>> CreateAsync(ReservaModel modelo)
        {
            OperationResult<ReservaModel> result = new OperationResult<ReservaModel>();

            _logger.LogInformation("Proceso para crear una reserva");

            try
            {
                var reserva = new Reserva
                {
                    IdCliente = modelo.IdCliente,
                    IdHabitacion = modelo.IdHabitacion,
                    FechaEntrada = modelo.FechaEntrada,
                    FechaSalida = modelo.FechaSalida,
                    FechaSalidaConfirmacion = modelo.FechaSalidaConfirmacion,
                    PrecioInicial = modelo.PrecioInicial,
                    Adelanto = modelo.Adelanto,
                    PrecioRestante = modelo.PrecioRestante,
                    TotalPagado = modelo.TotalPagado,
                    CostoPenalidad = modelo.CostoPenalidad,
                    Observacion = modelo.Observacion,
                    FechaCreacion = DateTime.Now,
                    Estado = true,
                    UsuarioCreacion = modelo.UsuarioCreacion,
                    FechaEliminado = modelo.FechaEliminado,
                    UsuarioActualizacion = modelo.UsuarioActualizacion,
                    FechaActualizacion = modelo.FechaActualizacion
                };

                _dbSet.AddAsync(reserva);
                await _context.SaveChangesAsync();

                var reservaModel = new ReservaModel
                {
                    IdCliente = modelo.IdCliente,
                    IdHabitacion = modelo.IdHabitacion,
                    FechaEntrada = modelo.FechaEntrada,
                    FechaSalida = modelo.FechaSalida,
                    FechaSalidaConfirmacion = modelo.FechaSalidaConfirmacion,
                    PrecioInicial = modelo.PrecioInicial,
                    Adelanto = modelo.Adelanto,
                    PrecioRestante = modelo.PrecioRestante,
                    TotalPagado = modelo.TotalPagado,
                    CostoPenalidad = modelo.CostoPenalidad,
                    Observacion = modelo.Observacion,
                    FechaCreacion = DateTime.Now,
                    Estado = true,
                    UsuarioCreacion = modelo.UsuarioCreacion,
                    FechaEliminado = modelo.FechaEliminado,
                    UsuarioActualizacion = modelo.UsuarioActualizacion,
                    FechaActualizacion = modelo.FechaActualizacion
                };

                result = OperationResult<ReservaModel>.Succes("Reserva creada correctamente", reservaModel);
                _logger.LogInformation("Reserva creada correctamente");
            }
            catch (Exception e) 
            {
                result = OperationResult<ReservaModel>.Failure("Error al crear una reserva" + e.Message);
                _logger.LogError("Error al crear una reserva" + e.Message);
            }
            return result;
        }

        public async Task<OperationResult<ReservaModel>> DeleteAsync(int Id, int IdUsuario)
        {
            OperationResult<ReservaModel> result = new OperationResult<ReservaModel>();

            _logger.LogInformation("Procesa para eliminar una reserva");
            try
            {
                var reserva = await _dbSet.FirstOrDefaultAsync(c => c.IdReserva == Id || c.UsuarioActualizacion == IdUsuario);

                if (reserva == null)
                    return result = OperationResult<ReservaModel>.Failure("No se encontraron los datos a eliminar");


                reserva.Estado = false;
                reserva.Borrado = true;
                reserva.FechaEliminado = DateTime.Now;
                reserva.UsuarioEliminacion = IdUsuario;

                _dbSet.Update(reserva);
                await _context.SaveChangesAsync();

                result = OperationResult<ReservaModel>.Succes("Datos eliminados correctamente");
                _logger.LogInformation("Reserva eliminada correctamente");
            }
            catch (Exception e) 
            {
                result = OperationResult<ReservaModel>.Failure("Error eliminando los datos" + e.Message);
                _logger.LogError("Error eliminando los datos" + e.Message);
            }
            return result;
        }

        public async Task<OperationResult<IEnumerable<ReservaModel>>> GetAllAsync()
        {
            OperationResult<IEnumerable<ReservaModel>> result = new OperationResult<IEnumerable<ReservaModel>>();

            _logger.LogInformation("Proceso para cargar todos los datos de la reserva");

            try
            {
                var reserva = await _dbSet.ToListAsync();

                var reservaModel = reserva.Select(modelo => new ReservaModel
                {
                    IdReserva = modelo.IdReserva,
                    IdCliente = modelo.IdCliente,
                    IdHabitacion = modelo.IdHabitacion,
                    FechaEntrada = modelo.FechaEntrada,
                    FechaSalida = modelo.FechaSalida,
                    FechaSalidaConfirmacion = modelo.FechaSalidaConfirmacion,
                    PrecioInicial = modelo.PrecioInicial,
                    Adelanto = modelo.Adelanto,
                    PrecioRestante = modelo.PrecioRestante,
                    TotalPagado = modelo.TotalPagado,
                    CostoPenalidad = modelo.CostoPenalidad,
                    Observacion = modelo.Observacion,
                    FechaCreacion = modelo.FechaCreacion,
                    UsuarioCreacion = modelo.UsuarioCreacion,
                    FechaEliminado = modelo.FechaEliminado,
                    UsuarioActualizacion = modelo.UsuarioActualizacion,
                    FechaActualizacion = modelo.FechaActualizacion,
                    Estado = modelo.Estado
                });

                if (reservaModel == null)
                    return result = OperationResult<IEnumerable<ReservaModel>>.Failure("No se encontralos los datos");

                result = OperationResult<IEnumerable<ReservaModel>>.Succes("Datos cargados correctamente", reservaModel);
                _logger.LogInformation("Datos cargados correctamente");
            }
            catch (Exception e) 
            {
                result = OperationResult<IEnumerable<ReservaModel>>.Failure("Error Cargando los datos" + e.Message);
                _logger.LogError("Error cargando los datos");
            }
            return result;
        }

        public async Task<OperationResult<ReservaModel>> GetByIdAsync(int Id)
        {
            OperationResult<ReservaModel> result = new OperationResult<ReservaModel>();

            _logger.LogInformation("Proceso para cargar la reserva por ID");

            try
            {
                var reserva = await _dbSet.Where(c => c.IdReserva == Id).Select(modelo => new ReservaModel
                {
                    IdReserva = modelo.IdReserva,
                    IdCliente = modelo.IdCliente,
                    IdHabitacion = modelo.IdHabitacion,
                    FechaEntrada = modelo.FechaEntrada,
                    FechaSalida = modelo.FechaSalida,
                    FechaSalidaConfirmacion = modelo.FechaSalidaConfirmacion,
                    PrecioInicial = modelo.PrecioInicial,
                    Adelanto = modelo.Adelanto,
                    PrecioRestante = modelo.PrecioRestante,
                    TotalPagado = modelo.TotalPagado,
                    CostoPenalidad = modelo.CostoPenalidad,
                    Observacion = modelo.Observacion,
                    Estado = modelo.Estado,
                    Borrado = modelo.Borrado,
                    FechaCreacion = modelo.FechaCreacion,
                    UsuarioCreacion = modelo.UsuarioCreacion,
                    FechaEliminado = modelo.FechaEliminado,
                    UsuarioActualizacion = modelo.UsuarioActualizacion,
                    FechaActualizacion = modelo.FechaActualizacion
                }).FirstOrDefaultAsync();

                if (reserva == null)
                    return result = OperationResult<ReservaModel>.Failure("Datos no encontrados");

                result = OperationResult<ReservaModel>.Succes("Datos cargados correctamente",reserva);
                _logger.LogInformation("Datos cargados correctamente");
            }
            catch (Exception e) 
            {
                result = OperationResult<ReservaModel>.Failure("Error cargando los datos" + e.Message);
                _logger.LogError("Error cargando los datos" + e.Message);
            }
            return result;
        }

        public async Task<OperationResult<ReservaModel>> UpdateAsync(ReservaModel modelo)
        {
            OperationResult<ReservaModel> result = new OperationResult<ReservaModel>();

            _logger.LogInformation("Proceso para actualizar una reserva");

            try
            {
                if (modelo == null || modelo.IdReserva == null || modelo.UsuarioActualizacion == null)
                    return result = OperationResult<ReservaModel>.Failure("No se encontraron los datos");

                var reserva = await _dbSet.FirstOrDefaultAsync(c => c.IdReserva == modelo.IdReserva || c.UsuarioActualizacion == modelo.UsuarioActualizacion);

                    reserva.IdCliente = modelo.IdCliente;
                    reserva.IdHabitacion = modelo.IdHabitacion;
                    reserva.FechaEntrada = modelo.FechaEntrada;
                    reserva.FechaSalida = modelo.FechaSalida;
                    reserva.FechaSalidaConfirmacion = modelo.FechaSalidaConfirmacion;
                    reserva.PrecioInicial = modelo.PrecioInicial;
                    reserva.Adelanto = modelo.Adelanto;
                    reserva.PrecioRestante = modelo.PrecioRestante;
                    reserva.TotalPagado = modelo.TotalPagado;
                    reserva.CostoPenalidad = modelo.CostoPenalidad;
                    reserva.Observacion = modelo.Observacion;

                    modelo.UsuarioActualizacion = modelo.UsuarioActualizacion;
                    modelo.FechaActualizacion = DateTime.Now;

                _dbSet.Update(reserva);
                await _context.SaveChangesAsync();

                result = OperationResult<ReservaModel>.Succes("Datos actaulizados correctamente");
                _logger.LogInformation("Datos actualizados correctamente");
            }
            catch (Exception e) 
            {
                result = OperationResult<ReservaModel>.Failure("Error actualizando los datos" + e.Message);
                _logger.LogError("Error cargando los datos" + e.Message);
            }
            return result;
        }
    }
}
