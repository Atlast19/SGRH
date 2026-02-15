using Microsoft.AspNetCore.Mvc;
using SGRH.Application.DTOs.Usuarios.UsuarioDto;
using SGRH.Application.Interfaces.Usuarios;
using System.Threading.Tasks.Dataflow;

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
        public async Task<IActionResult> Create(CreateUsuarioDto model) 
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
                return BadRequest("No se Encontro el Uusario Solicitado");

            var result = await _service.GetByIdAsync(Id);

            if (result == null)
                return BadRequest("No se Encontro el Usuario Solicitado");

            return Ok(result);
        }

        [HttpDelete("DeleteUsuario")]
        public async Task<IActionResult> Delete(int Id, int IdUsuario) 
        {
            if (Id <= 0 || IdUsuario <= 0)
                return BadRequest("No se Enctontro el Usuario a Eliminar");

            var result = await _service.DeleteAsync(Id,IdUsuario);

            if (result == null)
                return BadRequest("No se Encontro el Uusario a Eliminar");

            return Ok(result);
        }

        [HttpPut("UpdateUsuario")]
        public async Task<IActionResult> Update(UpdateUsuarioDto model)
        {
            var result = await _service.UpdateAsync(model);

            return Ok(result);
        }

    }
}
