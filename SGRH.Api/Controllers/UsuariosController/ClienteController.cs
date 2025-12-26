using Microsoft.AspNetCore.Mvc;
using SGRH.Application.Interfaces.Usuarios;
using SGRH.Domein.Entitys;
using SGRH.Domein.Models.Usuarios;
using System.Diagnostics.Contracts;

namespace SGRH.Api.Controllers.UsuariosController
{
    [Route("Api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        [HttpPost("CreateCliente")]
        public async Task<IActionResult> CreateCliente(ClienteModel modelo) 
        {
            var result = await _service.CreateAsync(modelo);

            if (!result.IsSucces)
                return BadRequest(result);


            return Ok(result);
        }
        [HttpGet("GetAllClientes")]
        public async Task<IActionResult> GetAll() 
        {
            var result = await _service.GetAllAsync();

            if (!result.IsSucces)
                return BadRequest(result);


            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id) 
        {
            var result = await _service.GetByIdAsync(id);

            if (!result.IsSucces)
                return BadRequest(result);


            return Ok(result);
        }

        [HttpDelete("DeleteById")]
        public async Task<IActionResult> DeleteById(int id, int IdUsuario) 
        {
            var result = await _service.DeleteAsync(id, IdUsuario);

            if (!result.IsSucces)
                return BadRequest(result);


            return Ok(result);
        }

        [HttpPut("UpdateCliente")]
        public async Task<IActionResult> Update(ClienteModel modelo) 
        {
            var result = await _service.UpdateAsync(modelo);

            if (!result.IsSucces)
                return BadRequest(result);


            return Ok(result);
        }
    }
}
