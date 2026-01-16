using Microsoft.AspNetCore.Mvc;
using SGRH.Application.DTOs.Reserva;
using SGRH.Application.Interfaces.Services;

namespace SGRH.Api.Controllers.ServiciosController
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ReservaController : Controller
    {
        private readonly IReservaServices _service;

        public ReservaController(IReservaServices service)
        {
            _service = service;
        }

        [HttpPost("CreateReserva")]

        public async Task<IActionResult> Create(ReservaDTO modelo) 
        {
            var result = await _service.CreateAsync(modelo);

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

        [HttpDelete("DeleteReserva")]

        public async Task<IActionResult> Delete(int Id, int IdUsuario) 
        {
            var result = await _service.DeleteAsync(Id, IdUsuario);

            if (!result.IsSucces)
                return BadRequest(result);


            return Ok(result);
        }

        [HttpPut("UpdateReserva")]

        public async Task<IActionResult> Update(ReservaDTO modelo) 
        {
            var result = await _service.UpdateAsync(modelo);

            if (!result.IsSucces)
                return BadRequest(result);


            return Ok(result);
        }
    }
}
