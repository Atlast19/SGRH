using Microsoft.AspNetCore.Mvc;
using SGRH.Application.DTOs.Usuarios;
using SGRH.Application.DTOs.Usuarios.ClienteDto;
using SGRH.Application.Interfaces.Usuarios;


namespace SGRH.Api.Controllers.UsuariosController
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        [HttpPost("CreateCliente")]
        public async Task<IActionResult> CreateCliente(CreateClienteDto modelo) 
        {
            var result = await _service.CreateAsync(modelo);


            return Ok(result);
        }
        [HttpGet("GetAllClientes")]
        public async Task<IActionResult> GetAll() 
        {
            var result = await _service.GetAllAsync();


            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id) 
        {
            var result = await _service.GetByIdAsync(id);


            return Ok(result);
        }

        [HttpDelete("DeleteById")]
        public async Task<IActionResult> DeleteById(int id, int IdUsuario) 
        {
            var result = await _service.DeleteAsync(id, IdUsuario);


            return Ok(result);
        }

        [HttpPut("UpdateCliente")]
        public async Task<IActionResult> Update(UpdateClienteDto modelo) 
        {
            var result = await _service.UpdateAsync(modelo);


            return Ok(result);
        }
    }
}
