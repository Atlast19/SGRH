using Microsoft.AspNetCore.Mvc;
using SGRH.Application.Interfaces.habitacion;
using SGRH.Domein.Models.Habitaciones;

namespace SGRH.Api.Controllers.HabitacionController
{
    [ApiController]
    [Route("Api/[controller]")]
    public class EstadoHabitacionController : Controller
    {
        private readonly IEstadoHabitacionService _service;

        public EstadoHabitacionController(IEstadoHabitacionService service)
        {
            _service = service;
        }

        [HttpPost("CreateEstadoHabitacion")]

        public async Task<IActionResult> Creat(EstadoHabitacionModel modelo) 
        {
            var result = await _service.CreateAsync(modelo);

            if (!result.IsSucces)
                return BadRequest(result);


            return Ok(result);
        }

        [HttpGet("GetAllEstadoHabitacion")]

        public async Task<IActionResult> GetAll() 
        {
            var result = await _service.GetAllAsync();

            if (!result.IsSucces)
                return BadRequest(result);


            return Ok(result);
        }

        [HttpGet("GetEstadoHabitacionById")]

        public async Task<IActionResult> GetById(int Id) 
        {
            var result = await _service.GetByIdAsync(Id);

            if (!result.IsSucces)
                return BadRequest(result);


            return Ok(result);
        }

        [HttpDelete("DeleteEstadoHabitacion")]

        public async Task<IActionResult> Delete(int Id, int IdUsuario) 
        {
            var result = await _service.DeleteAsync(Id, IdUsuario);

            if (!result.IsSucces)
                return BadRequest(result);


            return Ok(result);
        }

        [HttpPut("UpdateEstadoHabitacion")]

        public async Task<IActionResult> Update(EstadoHabitacionModel modelo) 
        {
            var result = await _service.UpdateAsync(modelo);

            if (!result.IsSucces)
                return BadRequest(result);


            return Ok(result);
        }

        
    }
}
