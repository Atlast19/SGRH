
using SGRH.Application.DTOs.Reserva;
using SGRH.Application.Interfaces.Services;
using SGRH.Domein.Base;
using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Servicios;


namespace SGRH.Application.Services.Servicios
{
    public class ServicioService : IServicioService
    {
        private readonly IServicioRepository _repository;

        public ServicioService(IServicioRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult<ServicioDTO>> CreateAsync(ServicioDTO dto)
        {
            var Servicio = new Servicio();

            Servicio.Nombre = dto.Nombre;
            Servicio.Descripcion = dto.Descripcion;
            Servicio.UsuarioCreacion = dto.UsuarioCreacion;
            Servicio.FechaCreacion = dto.FechaCreacion;
            Servicio.Estado = true;
            Servicio.Borrado = false;

            await _repository.CreateAsync(Servicio);

            var resultDto = new ServicioDTO 
            {
                IdServicio = Servicio.IdServicio,
                Nombre = Servicio.Nombre,
                Descripcion = Servicio.Descripcion,
                UsuarioCreacion = Servicio.UsuarioCreacion,
                FechaCreacion = Servicio.FechaCreacion,
                UsuarioEliminacion = Servicio.UsuarioEliminacion,
                FechaEliminado = Servicio.FechaEliminado,
                UsuarioActualizacion = Servicio.UsuarioActualizacion,
                FechaActualizacion = Servicio.FechaActualizacion,
                Estado = Servicio.Estado,
                Borrado = Servicio.Borrado
            };

            return OperationResult<ServicioDTO>.Succes("Datos agregados correctamente", resultDto);

        }

        public async Task<OperationResult<ServicioDTO>> DeleteAsync(int Id, int IdUsuario)
        {
            var Servicio = await _repository.GetByIdAsync(Id);

            if (Servicio == null || Servicio.Borrado)
                return OperationResult<ServicioDTO>.Failure("No se encontraron los datos a eliminar");

            Servicio.Borrado = true;
            Servicio.Estado = false;
            Servicio.UsuarioEliminacion = IdUsuario;
            Servicio.FechaEliminado = DateTime.Now;

            await _repository.UpdateAsync(Servicio);

            var resultDto = new ServicioDTO
            {
                IdServicio = Servicio.IdServicio,
                Nombre = Servicio.Nombre,
                Descripcion = Servicio.Descripcion,
                UsuarioCreacion = Servicio.UsuarioCreacion,
                FechaCreacion = Servicio.FechaCreacion,
                UsuarioEliminacion = Servicio.UsuarioEliminacion,
                FechaEliminado = Servicio.FechaEliminado,
                UsuarioActualizacion = Servicio.UsuarioActualizacion,
                FechaActualizacion = Servicio.FechaActualizacion,
                Estado = Servicio.Estado,
                Borrado = Servicio.Borrado
            };

            return OperationResult<ServicioDTO>.Succes("Datos eliminados correctamente", resultDto);
        }

        public async Task<OperationResult<IEnumerable<ServicioDTO>>> GetAllAsync()
        {
            var Servicio = await _repository.GetAllAsync();

            if (!Servicio.Any())
                return OperationResult<IEnumerable<ServicioDTO>>.Failure("No se encotnraron los datos");

            var dto = Servicio.Where(c => !c.Borrado)
                .Select(c => new ServicioDTO 
                {
                    IdServicio = c.IdServicio,
                    Nombre = c.Nombre,
                    Descripcion = c.Descripcion,
                    UsuarioCreacion = c.UsuarioCreacion,
                    FechaCreacion = c.FechaCreacion,
                    UsuarioEliminacion = c.UsuarioEliminacion,
                    FechaEliminado = c.FechaEliminado,
                    UsuarioActualizacion = c.UsuarioActualizacion,
                    FechaActualizacion = c.FechaActualizacion,
                    Estado = c.Estado,
                    Borrado = c.Borrado
                });

            return OperationResult<IEnumerable<ServicioDTO>>.Succes("Datos cargados correctamente",dto);
        }

        public async Task<OperationResult<ServicioDTO>> GetByIdAsync(int Id)
        {
            var Servicio = await _repository.GetByIdAsync(Id);

            if (Servicio == null || Servicio.Borrado)
                return OperationResult<ServicioDTO>.Failure("No se encontraron los datos solicitados");

            var resultDto = new ServicioDTO
            {
                IdServicio = Servicio.IdServicio,
                Nombre = Servicio.Nombre,
                Descripcion = Servicio.Descripcion,
                UsuarioCreacion = Servicio.UsuarioCreacion,
                FechaCreacion = Servicio.FechaCreacion,
                UsuarioEliminacion = Servicio.UsuarioEliminacion,
                FechaEliminado = Servicio.FechaEliminado,
                UsuarioActualizacion = Servicio.UsuarioActualizacion,
                FechaActualizacion = Servicio.FechaActualizacion,
                Estado = Servicio.Estado,
                Borrado = Servicio.Borrado
            };

            return OperationResult<ServicioDTO>.Succes("Datos cargados correctamente", resultDto);
        }

        public async Task<OperationResult<ServicioDTO>> UpdateAsync(ServicioDTO dto)
        {
           var Servicio = await _repository.GetByIdAsync(dto.IdServicio);

            if (Servicio == null || Servicio.Borrado)
                return OperationResult<ServicioDTO>.Failure("No se encontraron los datos a actualizar");


            Servicio.Nombre = dto.Nombre;
            Servicio.Descripcion = dto.Descripcion;
            Servicio.UsuarioActualizacion = dto.UsuarioActualizacion;
            Servicio.FechaActualizacion = DateTime.Now;

            await _repository.UpdateAsync(Servicio);

            var resultDto = new ServicioDTO
            {
                IdServicio = Servicio.IdServicio,
                Nombre = Servicio.Nombre,
                Descripcion = Servicio.Descripcion,
                UsuarioCreacion = Servicio.UsuarioCreacion,
                FechaCreacion = Servicio.FechaCreacion,
                UsuarioEliminacion = Servicio.UsuarioEliminacion,
                FechaEliminado = Servicio.FechaEliminado,
                UsuarioActualizacion = Servicio.UsuarioActualizacion,
                FechaActualizacion = Servicio.FechaActualizacion,
                Estado = Servicio.Estado,
                Borrado = Servicio.Borrado
            };

            return OperationResult<ServicioDTO>.Succes("Datos actualizados correctamente", resultDto);
        }
    }
}
