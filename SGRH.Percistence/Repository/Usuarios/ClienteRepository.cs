using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGRH.Domein.Base;
using SGRH.Domein.Entitys;
using SGRH.Domein.Interfaces.Usuarios;
using SGRH.Domein.Models.Usuarios;
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

        public async Task<OperationResult<ClienteModel>> CreateAsync(ClienteModel modelo)
        {
            OperationResult<ClienteModel> result = new OperationResult<ClienteModel>();

            try
            {
                var cliente = new Cliente
                {

                    TipoDocumento = modelo.TipoDocumento,
                    Documento = modelo.Documento,
                    NombreCompleto = modelo.NombreCompleto,
                    Correo = modelo.Correo,
                    UsuarioCreacion = modelo.UsuarioCreacion,
                    FechaCreacion = DateTime.Now,
                    Estado = true
                };

                await _dbSet.AddAsync(cliente);
                await _context.SaveChangesAsync();

                var clienteModel = new ClienteModel
                {
                    TipoDocumento = modelo.TipoDocumento,
                    Documento = modelo.Documento,
                    NombreCompleto = modelo.NombreCompleto,
                    Correo = modelo.Correo,
                    UsuarioCreacion = modelo.UsuarioCreacion,
                    FechaCreacion = DateTime.Now,
                    Estado = true
                };

                result = OperationResult<ClienteModel>.Succes("Datos Agregados correctamente" + clienteModel);


            }
            catch (Exception e) 
            {
                result = OperationResult<ClienteModel>.Failure("Error ingresando los datos" + e.Message);
            }
            return result;
        }

        public async Task<OperationResult<ClienteModel>> DeleteAsync(int Id, int IdUsuario)
        {
            OperationResult<ClienteModel> result = new OperationResult<ClienteModel>();

            try
            {
                var cliente = await _dbSet.FirstOrDefaultAsync(c => c.IdCliente == Id);

                if (cliente == null)
                    result = OperationResult<ClienteModel>.Failure("Datos no encontrados");

                if(IdUsuario <= 0)
                    result = OperationResult<ClienteModel>.Failure("Se requiere el Id del usuario");


                cliente.Estado = false;
                cliente.Borrado = true;
                cliente.FechaEliminado = DateTime.Now;
                cliente.UsuarioEliminacion = IdUsuario;

                 _dbSet.Update(cliente);
                 await _context.SaveChangesAsync();

                result = OperationResult<ClienteModel>.Succes("Datos eliminados corectamente");

            }
            catch (Exception e) 
            {
                result = OperationResult<ClienteModel>.Failure("Error eliminando los datos" + e.Message);
            }
            return result;
        }

        public async Task<OperationResult<IEnumerable<ClienteModel>>> GetAllAsync()
        {
            OperationResult<IEnumerable<ClienteModel>> result = new OperationResult<IEnumerable<ClienteModel>>();

            try
            {
                var cliente = await _dbSet.ToListAsync();

                var clientes = cliente.Select(c => new ClienteModel
                {
                    IdCliente = c.IdCliente,
                    TipoDocumento = c.TipoDocumento,
                    Documento = c.Documento,
                    NombreCompleto = c.NombreCompleto,
                    Correo = c.Correo,
                    Estado = c.Estado,
                    UsuarioCreacion = c.UsuarioCreacion,
                    FechaCreacion = c.FechaCreacion,
                    Borrado = c.Borrado,
                    UsuarioActualizacion = c.UsuarioActualizacion,
                    UsuarioEliminacion = c.UsuarioEliminacion,
                    FechaEliminado = c.FechaEliminado,
                    FechaActualizacion = c.FechaActualizacion

                });

                if (clientes == null)
                    return result = OperationResult<IEnumerable<ClienteModel>>.Failure("Error procesando los datos");

                result = OperationResult<IEnumerable<ClienteModel>>.Succes("Datos procesados correctamente", clientes);
            }
            catch (Exception e) 
            {
                result = OperationResult<IEnumerable<ClienteModel>>.Failure($"Error procesando los datos: {e.Message} ");
                _logger.LogError("Error cargando los datos" + e.Message);
            }
            return result;
        }

        public async Task<OperationResult<ClienteModel>> GetByIdAsync(int Id)
        {
            OperationResult<ClienteModel> result = new OperationResult<ClienteModel>();

            try
            {
                var cliente = await _dbSet.Where(c => c.IdCliente == Id).Select(c => new ClienteModel 
                {
                    IdCliente = c.IdCliente,
                    TipoDocumento = c.TipoDocumento,
                    Documento = c.Documento,
                    NombreCompleto = c.NombreCompleto,
                    Correo = c.Correo,
                    Estado = c.Estado,
                    UsuarioCreacion = c.UsuarioCreacion,
                    FechaCreacion = c.FechaCreacion,
                    Borrado = c.Borrado,
                    UsuarioActualizacion = c.UsuarioActualizacion,
                    UsuarioEliminacion = c.UsuarioEliminacion,
                    FechaEliminado = c.FechaEliminado,
                    FechaActualizacion = c.FechaActualizacion
                }).FirstOrDefaultAsync();

                if (cliente == null)
                    return result = OperationResult<ClienteModel>.Failure("Error procesando los datos");

                result = OperationResult<ClienteModel>.Succes("Datos procesados correctamente", cliente);
            }
            catch (Exception e)
            {
                result = OperationResult<ClienteModel>.Failure($"Error procesando los datos: {e.Message} ");
                _logger.LogError("Error cargando los datos" + e.Message);
            }
            return result;
        }

        public async Task<OperationResult<ClienteModel>> UpdateAsync(ClienteModel modelo)
        {
            OperationResult<ClienteModel> result = new OperationResult<ClienteModel>();

            try
            {
                if (modelo == null || modelo.IdCliente <= 0)
                    return result = OperationResult<ClienteModel>.Failure("El cliente es invalido");

                if (modelo.UsuarioActualizacion == null || modelo.UsuarioActualizacion <= 0)
                    return OperationResult<ClienteModel>.Failure("Usuario de actualización inválido");

                var cliente = await _dbSet.FirstOrDefaultAsync(c => c.IdCliente == modelo.IdCliente);

                
                cliente.TipoDocumento = modelo.TipoDocumento;
                cliente.Documento = modelo.Documento;
                cliente.NombreCompleto = modelo.NombreCompleto;
                cliente.Correo = modelo.Correo;

                cliente.UsuarioActualizacion = modelo.UsuarioActualizacion;
                cliente.FechaActualizacion = DateTime.Now;

                _dbSet.Update(cliente);
                await _context.SaveChangesAsync();

                result = OperationResult<ClienteModel>.Succes("Datos Actualizados correctamente");

            }
            catch (Exception e)
            {
                result = OperationResult<ClienteModel>.Failure("Error Actualizando los datos" + e.Message);
            }
            return result;
        }
    }
}
