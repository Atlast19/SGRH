using Microsoft.AspNetCore.Mvc;
using SGRH.Application.Interfaces.Services;
using SGRH.Domein.Models.Servicios;

namespace SGRH.Api.Controllers.ServiciosController
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class ServicioController : Controller
    {
        private readonly IServicioService _service;

        public ServicioController(IServicioService service)
        {
            _service = service;
        }

        [HttpPost("CreateServicio")]
        public async Task<IActionResult> Create(ServicioModel modelo) 
        {
            var result = await _service.CreateAsync(modelo);

            if (!result.IsSucces)
                return BadRequest(result);


            return Ok(result);
        }

        [HttpGet("GetAllServicio")]

        public async Task<IActionResult> Getall() 
        {
            var result = await _service.GetAllAsync();

            if (!result.IsSucces)
                return BadRequest(result);


            return Ok(result);
        }

        [HttpGet("GetByID")]

        public async Task<IActionResult> GetById(int Id) 
        {
            var result = await _service.GetByIdAsync(Id);

            if (!result.IsSucces)
                return BadRequest(result);


            return Ok(result);
        }

        [HttpDelete("DeleteServicio")]

        public async Task<IActionResult> Deletele(int Id, int IdUsuario) 
        {
            var result = await _service.DeleteAsync(Id, IdUsuario);

            if (!result.IsSucces)
                return BadRequest(result);


            return Ok(result);
        }

        [HttpPut("UpdateServicio")]

        public async Task<IActionResult> Update(ServicioModel modelo) 
        {
            var result = await _service.UpdateAsync(modelo);

            if (!result.IsSucces)
                return BadRequest(result);


            return Ok(result);
        }
    }
}
