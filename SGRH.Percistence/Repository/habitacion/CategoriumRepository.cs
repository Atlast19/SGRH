
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGRH.Domein.Base;
using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Habitaciones;
using SGRH.Percistence.Context;

namespace SGRH.Percistence.Repository.Habitaciones
{
    public class CategoriumRepository : ICategoriumRepository
    {
        private readonly SGHRContext _context;
        private readonly ILogger<CategoriumRepository> _logger;
        DbSet<Categorium> _dbSet;
        public CategoriumRepository(SGHRContext context, ILogger<CategoriumRepository> logger)
        {
            _context = context;
            _logger = logger;
            _dbSet = context.Set<Categorium>();
        }
        public async Task CreateAsync(Categorium Entity)
        {
            _logger.LogInformation("Proceso para crear una categoria");

            await _dbSet.AddAsync(Entity);
            await _context.SaveChangesAsync();

        }

        public async Task  DeleteAsync(int Id, int IdUsuario)
        {
            OperationResult<Categorium> result = new OperationResult<Categorium>();
            _logger.LogInformation("Proceso parra eliminar una categoria");
            
            var categoria = await _dbSet.FirstOrDefaultAsync(c => c.IdCategoria == Id && !c.Borrado);
            
            if (categoria == null)
                return;
            
            categoria.Borrado = true;
            categoria.Estado = false;
            categoria.UsuarioEliminacion = IdUsuario;
            categoria.FechaEliminado = DateTime.Now;
            
            _dbSet.Update(categoria);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Categorium>> GetAllAsync()
        {
            _logger.LogInformation("Proeso para cargar todas las categorias");
            
            return await _dbSet.ToListAsync();
        }

        public async Task<Categorium?> GetByIdAsync(int Id)
        {

            _logger.LogInformation("Proceso para cargar los datos por ID");


            return await _dbSet.FirstOrDefaultAsync(c => c.IdCategoria == Id);

        }

        public async Task UpdateAsync(Categorium Entity)
        {

            _logger.LogInformation("Proceso para actualizar la categoria");



                var categoria = await _dbSet.FirstOrDefaultAsync(c => c.IdCategoria == Entity.IdCategoria && !c.Borrado);

                categoria.Descripcion = Entity.Descripcion;
                categoria.IdServicio = Entity.IdServicio;
                categoria.FechaActualizacion = DateTime.Now;
                categoria.UsuarioActualizacion = Entity.UsuarioActualizacion;

                _dbSet.Update(categoria);
                 await _context.SaveChangesAsync();

        }
    }
}
