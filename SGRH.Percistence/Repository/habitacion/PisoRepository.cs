

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGRH.Domein.Base;
using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Habitaciones;

using SGRH.Percistence.Context;


namespace SGRH.Percistence.Repository.Habitaciones
{
    public class PisoRepository : IPisoRepository
    {
        private readonly SGHRContext _context;
        private readonly ILogger<PisoRepository> _logger;
        DbSet<Piso> _dbSet;
        public PisoRepository(SGHRContext context, ILogger<PisoRepository> logger)
        {
            _context = context;
            _logger = logger;
            _dbSet = context.Set<Piso>();
        }

        public async Task CreateAsync(Piso Entity)
        {
            _logger.LogInformation("Proceso para crear un piso");


            await _dbSet.AddAsync(Entity);
            await _context.SaveChangesAsync();


        }

        public async Task DeleteAsync(int Id, int IdUsuario)
        {

            _logger.LogInformation("Proceso para eliminar los datos");

            var Piso = await _dbSet.FirstOrDefaultAsync(c => c.IdPiso == Id && !c.Borrado);

            Piso.Estado = false;
            Piso.Borrado = true;
            Piso.FechaEliminado = DateTime.Now;
            Piso.UsuarioEliminacion = IdUsuario;

            _dbSet.Update(Piso);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Piso>> GetAllAsync()
        {

            _logger.LogInformation("Proceso para cargar los datos de piso");

            return await _dbSet.ToListAsync();
        }

        public async Task<Piso?> GetByIdAsync(int Id)
        {
            _logger.LogInformation("Proceso para cargar los datos por ID");

            return await _dbSet.FirstOrDefaultAsync(c => c.IdPiso == Id && !c.Borrado);
        }

        public async Task UpdateAsync(Piso Entoty)
        {

            _logger.LogInformation("Proceso para actualizar un pido");

            var piso = await _dbSet.FirstOrDefaultAsync(c => c.IdPiso == Entoty.IdPiso && !c.Borrado);

            piso.Descripcion = Entoty.Descripcion;
            piso.UsuarioActualizacion = Entoty.UsuarioActualizacion;
            piso.FechaActualizacion = DateTime.Now;

            _dbSet.Update(piso);
            await _context.SaveChangesAsync();

        }
    }
}
