using Microsoft.AspNetCore.Mvc;
using SGRH.Application.DTOs.Usuarios;
using SGRH.Application.Interfaces.Usuarios;

namespace SGRH.Api.Controllers.UsuariosController
{
    [ApiController]
    [Route("Api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpPost("CreateUssuario")]
        public async Task<IActionResult> Create(UsuarioDTO model) 
        {
            var result = await _service.CreateAsync(model);

            if (!result.IsSucces)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll() 
        {
            var result = await _service.GetAllAsync();

            if(!result.IsSucces)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int Id) 
        {
            var result = await _service.GetByIdAsync(Id);

            if (!result.IsSucces)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("DeleteUsuario")]
        public async Task<IActionResult> Delete(int Id, int IdUsuario) 
        {
            var result = await _service.DeleteAsync(Id,IdUsuario);

            if (!result.IsSucces)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("UpdateUsuario")]
        public async Task<IActionResult> Update(UsuarioDTO model)
        {
            var result = await _service.UpdateAsync(model);

            if (!result.IsSucces)
                return BadRequest(result);

            return Ok(result);
        }

    }
}
