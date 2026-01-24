using SGRH.Application.DTOs.Reserva.ServicioDto;
using SGRH.Application.Interfaces.Services;
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

        public async Task<CreateServicioDto> CreateAsync(CreateServicioDto dto)
        {
            var Servicio = new Servicio();

            Servicio.Nombre = dto.Nombre;
            Servicio.Descripcion = dto.Descripcion;
            Servicio.UsuarioCreacion = dto.UsuarioCreacion;
            Servicio.FechaCreacion = dto.FechaCreacion;
            Servicio.Estado = true;

            await _repository.CreateAsync(Servicio);

            var resultDto = new CreateServicioDto 
            {
                Nombre = Servicio.Nombre,
                Descripcion = Servicio.Descripcion,
                UsuarioCreacion = Servicio.UsuarioCreacion,
                FechaCreacion = Servicio.FechaCreacion
            };

            return resultDto;

        }

        public async Task<DeleteServicioDto> DeleteAsync(int Id, int IdUsuario)
        {
            var Servicio = await _repository.GetByIdAsync(Id);

            Servicio.Borrado = true;
            Servicio.Estado = false;
            Servicio.UsuarioEliminacion = IdUsuario;
            Servicio.FechaEliminado = DateTime.Now;

            await _repository.UpdateAsync(Servicio);

            var resultDto = new DeleteServicioDto
            {
                IdServicio = Servicio.IdServicio,
                UsuarioEliminacion = Servicio.UsuarioEliminacion,
                FechaEliminado = Servicio.FechaEliminado,
                Estado = Servicio.Estado,
                Borrado = Servicio.Borrado
            };

            return resultDto;
        }

        public async Task<IEnumerable<ReadServicioDto>> GetAllAsync()
        {
            var Servicio = await _repository.GetAllAsync();

            var dto = Servicio.Where(c => !c.Borrado)
                .Select(c => new ReadServicioDto 
                {
                    IdServicio = c.IdServicio,
                    Nombre = c.Nombre,
                    Descripcion = c.Descripcion
                });

            return dto;
        }

        public async Task<ReadServicioDto> GetByIdAsync(int Id)
        {
            var Servicio = await _repository.GetByIdAsync(Id);

            var resultDto = new ReadServicioDto
            {
                IdServicio = Servicio.IdServicio,
                Nombre = Servicio.Nombre,
                Descripcion = Servicio.Descripcion
            };

            return resultDto;
        }

        public async Task<UpdateServicioDto> UpdateAsync(UpdateServicioDto dto)
        {
           var Servicio = await _repository.GetByIdAsync(dto.IdServicio);


            Servicio.Nombre = dto.Nombre;
            Servicio.Descripcion = dto.Descripcion;
            Servicio.UsuarioActualizacion = dto.UsuarioActualizacion;
            Servicio.FechaActualizacion = DateTime.Now;

            await _repository.UpdateAsync(Servicio);

            var resultDto = new UpdateServicioDto
            {
                IdServicio = Servicio.IdServicio,
                Nombre = Servicio.Nombre,
                Descripcion = Servicio.Descripcion,
                UsuarioActualizacion = Servicio.UsuarioActualizacion,
                FechaActualizacion = Servicio.FechaActualizacion
            };

            return resultDto;
        }
    }
}
