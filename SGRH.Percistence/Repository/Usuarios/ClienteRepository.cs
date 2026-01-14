using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Usuarios;
using SGRH.Percistence.Context;

namespace SGRH.Percistence.Repository.Usuario
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly SGHRContext _context;
        private readonly ILogger<ClienteRepository> _logger;
        DbSet<Cliente> _dbSet;
        public ClienteRepository(SGHRContext context, ILogger<ClienteRepository> logger)
        {
            _context = context;
            _logger = logger;
            _dbSet = context.Set<Cliente>();
        }

        public async Task CreateAsync(Cliente Entity)
        {
            _logger.LogInformation("Proceso para crear un cliente");
            
            await _dbSet.AddAsync(Entity);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int Id, int IdUsuario)
        {

            _logger.LogInformation("Proceso para eliminar un cliente");

            var cliente = await _dbSet.FirstOrDefaultAsync(c => c.IdCliente == Id && !c.Borrado);
            
            cliente.Estado = false;
            cliente.Borrado = true;
            cliente.FechaEliminado = DateTime.Now;
            cliente.UsuarioEliminacion = IdUsuario;

            _dbSet.Update(cliente);
            await _context.SaveChangesAsync();


        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {

            _logger.LogInformation("Proceso para cargar los clientes");
            
            return await _dbSet.ToListAsync();

        }

        public async Task<Cliente?> GetByIdAsync(int Id)
        {
            _logger.LogInformation("Proceso para cargar los clientes por ID");

            return await _dbSet.FirstOrDefaultAsync(c => c.IdCliente == Id && !c.Borrado);
        }

        public async Task UpdateAsync(Cliente modelo)
        {

            _logger.LogInformation("Proceso para actualizar un cliente");

            var cliente = await _dbSet.FirstOrDefaultAsync(c => c.IdCliente == modelo.IdCliente && !c.Borrado);
            
            cliente.TipoDocumento = modelo.TipoDocumento;
            cliente.Documento = modelo.Documento;
            cliente.NombreCompleto = modelo.NombreCompleto;
            cliente.Correo = modelo.Correo;

            cliente.UsuarioActualizacion = modelo.UsuarioActualizacion;
            cliente.FechaActualizacion = DateTime.Now;

            _dbSet.Update(cliente);
            await _context.SaveChangesAsync();

        }
    }
}
