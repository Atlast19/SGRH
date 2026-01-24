using Microsoft.AspNetCore.Mvc;
using SGRH.Application.DTOs.Reserva;
using SGRH.Application.DTOs.Reserva.ServicioDto;
using SGRH.Application.Interfaces.Services;

namespace SGRH.Api.Controllers.ServiciosController
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ServicioController : Controller
    {
        private readonly IServicioService _service;

        public ServicioController(IServicioService service)
        {
            _service = service;
        }

        [HttpPost("CreateServicio")]
        public async Task<IActionResult> Create(CreateServicioDto modelo) 
        {
            var result = await _service.CreateAsync(modelo);


            return Ok(result);
        }

        [HttpGet("GetAllServicio")]

        public async Task<IActionResult> Getall() 
        {
            var result = await _service.GetAllAsync();


            return Ok(result);
        }

        [HttpGet("GetByID")]

        public async Task<IActionResult> GetById(int Id) 
        {
            var result = await _service.GetByIdAsync(Id);


            return Ok(result);
        }

        [HttpDelete("DeleteServicio")]

        public async Task<IActionResult> Deletele(int Id, int IdUsuario) 
        {
            var result = await _service.DeleteAsync(Id, IdUsuario);


            return Ok(result);
        }

        [HttpPut("UpdateServicio")]

        public async Task<IActionResult> Update(UpdateServicioDto modelo) 
        {
            var result = await _service.UpdateAsync(modelo);


            return Ok(result);
        }
    }
}
