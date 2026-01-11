using Microsoft.AspNetCore.Mvc;
using SGRH.Application.Interfaces.Usuarios;
using SGRH.Domein.Models.Usuarios;

namespace SGRH.Api.Controllers.UsuariosController
{
    [ApiController]
    [Route("Api/[controller]")]
    public class RolUsuarioController : Controller
    {
        private readonly IRolUsuarioService _service;

        public RolUsuarioController(IRolUsuarioService service)
        {
            _service = service;
        }

        [HttpPost("CreateRolUsuario")]
        public async Task<IActionResult> Create(RolUsuarioModel model)
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

            if (!result.IsSucces)
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
            var result = await _service.DeleteAsync(Id, IdUsuario);

            if (!result.IsSucces)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("UpdateRolUsuario")]
        public async Task<IActionResult> Update(RolUsuarioModel model)
        {
            var result = await _service.UpdateAsync(model);

            if (!result.IsSucces)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
