using Microsoft.AspNetCore.Mvc;
using SGRH.Application.DTOs.Usuarios.RolUsuarioDto;
using SGRH.Application.Interfaces.Usuarios;

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
        public async Task<IActionResult> Create(CreateRolUsuarioDto model)
        {
            var result = await _service.CreateAsync(model);


            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int Id)
        {
            if (Id <= 0)
                return BadRequest("No se Encontro el Rol de Usuario Solicitado");

            var result = await _service.GetByIdAsync(Id);

            if (result == null)
                return BadRequest("No se Encontro el Rol de Usuario Solicitado");

            return Ok(result);
        }

        [HttpDelete("DeleteUsuario")]
        public async Task<IActionResult> Delete(int Id, int IdUsuario)
        {
            if (Id <= 0 || IdUsuario <= 0)
                return BadRequest("No se Encontro el Rol de Usuario a Eliminar");

            var result = await _service.DeleteAsync(Id, IdUsuario);

            if (result == null)
                return BadRequest("No se Encontro el Rol de Usuario a Eliminar");

            return Ok(result);
        }

        [HttpPut("UpdateRolUsuario")]
        public async Task<IActionResult> Update(UpdateRolUsuarioDto model)
        {
            var result = await _service.UpdateAsync(model);

            return Ok(result);
        }
    }
}
