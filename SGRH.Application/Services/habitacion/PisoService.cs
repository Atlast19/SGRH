using SGRH.Application.DTOs.Habitacion;
using SGRH.Application.Interfaces.habitacion;
using SGRH.Domein.Base;
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

        public async Task<OperationResult<PisoDTO>> CreateAsync(PisoDTO dto)
        {
            var Piso = new Piso();

            Piso.Descripcion = dto.Descripcion;
            Piso.UsuarioCreacion = dto.UsuarioCreacion;
            Piso.FechaCreacion = DateTime.Now;
            Piso.Estado = true;
            Piso.Borrado = false;


            await _respository.CreateAsync(Piso);

            var resultDto = new PisoDTO 
            {
                IdPiso = Piso.IdPiso,
                Descripcion = Piso.Descripcion,
                Estado = Piso.Estado,
                UsuarioCreacion = Piso.UsuarioCreacion,
                FechaCreacion = Piso.FechaCreacion,
                UsuarioEliminacion = Piso.UsuarioEliminacion,
                FechaEliminado = Piso.FechaEliminado,
                UsuarioActualizacion = Piso.UsuarioActualizacion,
                FechaActualizacion = Piso.FechaActualizacion,
                Borrado = Piso.Borrado
            };

            return OperationResult<PisoDTO>.Succes("Datos agregados correctamente",resultDto);
        }

        public async Task<OperationResult<PisoDTO>> DeleteAsync(int Id, int IdUsuario)
        {
            var Piso = await _respository.GetByIdAsync(Id);

            if (Piso == null || Piso.Borrado)
                return OperationResult<PisoDTO>.Failure("No se encontraron los datos aeliminar");

            Piso.Borrado = true;
            Piso.Estado = false;
            Piso.UsuarioEliminacion = IdUsuario;
            Piso.FechaEliminado = DateTime.Now;

            await _respository.UpdateAsync(Piso);

            var resultDto = new PisoDTO
            {
                IdPiso = Piso.IdPiso,
                Descripcion = Piso.Descripcion,
                Estado = Piso.Estado,
                UsuarioCreacion = Piso.UsuarioCreacion,
                FechaCreacion = Piso.FechaCreacion,
                UsuarioEliminacion = Piso.UsuarioEliminacion,
                FechaEliminado = Piso.FechaEliminado,
                UsuarioActualizacion = Piso.UsuarioActualizacion,
                FechaActualizacion = Piso.FechaActualizacion,
                Borrado = Piso.Borrado
            };

            return OperationResult<PisoDTO>.Succes("Datos eliminados correctamente", resultDto);
        }

        public async Task<OperationResult<IEnumerable<PisoDTO>>> GetAllAsync()
        {
            var Piso = await _respository.GetAllAsync();

            if (!Piso.Any())
                return OperationResult<IEnumerable<PisoDTO>>.Failure("No se encontraron datos");

            var dto = Piso.Where(c => !c.Borrado)
                .Select(c => new PisoDTO 
                {
                    IdPiso = c.IdPiso,
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

            return OperationResult<IEnumerable<PisoDTO>>.Succes("Datos cargados correctamente",dto);
        }

        public async Task<OperationResult<PisoDTO>> GetByIdAsync(int Id)
        {
            var Piso = await _respository.GetByIdAsync(Id);

            if (Piso == null || Piso.Borrado)
                return OperationResult<PisoDTO>.Failure("No se encontraron los datos solicitados");

            var resultDto = new PisoDTO
            {
                IdPiso = Piso.IdPiso,
                Descripcion = Piso.Descripcion,
                Estado = Piso.Estado,
                UsuarioCreacion = Piso.UsuarioCreacion,
                FechaCreacion = Piso.FechaCreacion,
                UsuarioEliminacion = Piso.UsuarioEliminacion,
                FechaEliminado = Piso.FechaEliminado,
                UsuarioActualizacion = Piso.UsuarioActualizacion,
                FechaActualizacion = Piso.FechaActualizacion,
                Borrado = Piso.Borrado
            };

            return OperationResult<PisoDTO>.Succes("Datos cargados correctamente", resultDto);
        }

        public async Task<OperationResult<PisoDTO>> UpdateAsync(PisoDTO dto)
        {

           var Piso = await _respository.GetByIdAsync(dto.IdPiso);

            if (Piso == null || Piso.Borrado)
                return OperationResult<PisoDTO>.Failure("No se encontraron los datos a actualizar");


            Piso.Descripcion = dto.Descripcion;
            Piso.UsuarioActualizacion = dto.UsuarioActualizacion;
            Piso.FechaActualizacion = DateTime.Now;

            await _respository.UpdateAsync(Piso);

            var resultDto = new PisoDTO
            {
                IdPiso = Piso.IdPiso,
                Descripcion = Piso.Descripcion,
                Estado = Piso.Estado,
                UsuarioCreacion = Piso.UsuarioCreacion,
                FechaCreacion = Piso.FechaCreacion,
                UsuarioEliminacion = Piso.UsuarioEliminacion,
                FechaEliminado = Piso.FechaEliminado,
                UsuarioActualizacion = Piso.UsuarioActualizacion,
                FechaActualizacion = Piso.FechaActualizacion,
                Borrado = Piso.Borrado
            };

            return OperationResult<PisoDTO>.Succes("Datos cargados correctamente", resultDto);
        }
    }
}
