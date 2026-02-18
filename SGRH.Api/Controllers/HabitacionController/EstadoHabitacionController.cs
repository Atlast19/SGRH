using Microsoft.AspNetCore.Mvc;
using SGRH.Application.DTOs.Habitacion.EstadoHabitacionDto;
using SGRH.Application.Interfaces.habitacion;


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

        public async Task<IActionResult> Creat(CreateEstadoHabitacionDto modelo) 
        {
            var result = await _service.CreateAsync(modelo);


            return Ok(result);
        }

        [HttpGet("GetAllEstadoHabitacion")]

        public async Task<IActionResult> GetAll() 
        {
            var result = await _service.GetAllAsync();


            return Ok(result);
        }

        [HttpGet("GetEstadoHabitacionById")]

        public async Task<IActionResult> GetById(int Id) 
        {
            var result = await _service.GetByIdAsync(Id);


            return Ok(result);
        }

        [HttpDelete("DeleteEstadoHabitacion")]

        public async Task<IActionResult> Delete(int Id, int IdUsuario) 
        {
            var result = await _service.DeleteAsync(Id, IdUsuario);


            return Ok(result);
        }

        [HttpPut("UpdateEstadoHabitacion")]

        public async Task<IActionResult> Update(UpdateEstadoHabitacionDto modelo) 
        {
            var result = await _service.UpdateAsync(modelo);


            return Ok(result);
        }

        
    }
}
