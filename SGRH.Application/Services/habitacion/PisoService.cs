using SGRH.Application.DTOs.Habitacion.PisoDto;
using SGRH.Application.Interfaces.habitacion;
using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Habitaciones;

namespace SGRH.Application.Services.habitacion
{
    public class PisoService : IPisoService
    {
        private readonly IPisoRepository _respository;

        public PisoService(IPisoRepository respository)
        {
            _respository = respository;
        }

        public async Task<CreatePisoDto> CreateAsync(CreatePisoDto dto)
        {
            var Piso = new Piso();

            Piso.Descripcion = dto.Descripcion;
            Piso.UsuarioCreacion = dto.UsuarioCreacion;
            Piso.FechaCreacion = DateTime.Now;
            Piso.Estado = true;


            await _respository.CreateAsync(Piso);

            var resultDto = new CreatePisoDto 
            {
                Descripcion = Piso.Descripcion,
                Estado = Piso.Estado,
                UsuarioCreacion = Piso.UsuarioCreacion,
                FechaCreacion = Piso.FechaCreacion
            };

            return resultDto;
        }

        public async Task<DeletePisoDto> DeleteAsync(int Id, int IdUsuario)
        {
            var Piso = await _respository.GetByIdAsync(Id);

            Piso.Borrado = true;
            Piso.Estado = false;
            Piso.UsuarioEliminacion = IdUsuario;
            Piso.FechaEliminado = DateTime.Now;

            await _respository.UpdateAsync(Piso);

            var resultDto = new DeletePisoDto
            {
                IdPiso = Piso.IdPiso,
                Estado = Piso.Estado,
                UsuarioEliminacion = Piso.UsuarioEliminacion,
                FechaEliminado = Piso.FechaEliminado,
                Borrado = Piso.Borrado
            };

            return resultDto;
        }

        public async Task<IEnumerable<ReadPisoDto>> GetAllAsync()
        {
            var Piso = await _respository.GetAllAsync();

            var dto = Piso.Where(c => !c.Borrado)
                .Select(c => new ReadPisoDto 
                {
                    IdPiso = c.IdPiso,
                    Descripcion = c.Descripcion
                });

            return dto;
        }

        public async Task<ReadPisoDto> GetByIdAsync(int Id)
        {
            var Piso = await _respository.GetByIdAsync(Id);

            var resultDto = new ReadPisoDto
            {
                IdPiso = Piso.IdPiso,
                Descripcion = Piso.Descripcion
            };

            return resultDto;
        }

        public async Task<UpdatePisoDto> UpdateAsync(UpdatePisoDto dto)
        {

           var Piso = await _respository.GetByIdAsync(dto.IdPiso);


            Piso.Descripcion = dto.Descripcion;
            Piso.UsuarioActualizacion = dto.UsuarioActualizacion;
            Piso.FechaActualizacion = DateTime.Now;

            await _respository.UpdateAsync(Piso);

            var resultDto = new UpdatePisoDto
            {
                IdPiso = Piso.IdPiso,
                Descripcion = Piso.Descripcion,
                Estado = Piso.Estado,
                UsuarioActualizacion = Piso.UsuarioActualizacion,
                FechaActualizacion = Piso.FechaActualizacion
            };

            return resultDto;
        }
    }
}
