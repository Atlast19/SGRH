using Microsoft.AspNetCore.Mvc;
using SGRH.Application.DTOs.Habitacion.HabitacionDto;
using SGRH.Application.Interfaces.habitacion;


namespace SGRH.Api.Controllers.HabitacionController
{
    [ApiController]
    [Route("Api/[controller]")]
    public class HabitacionController : Controller
    {
        private readonly IHabitacionService _service;

        public HabitacionController(IHabitacionService service)
        {
            _service = service;
        }

        [HttpPost("CreateHabitacion")]

        public async Task<IActionResult> Create(CreateHabitacionDto modelo) 
        {
            var result = await _service.CreateAsync(modelo);


            return Ok(result);
        }

        [HttpGet("GetAllHabitacion")]

        public async Task<IActionResult> GetAll() 
        {
            var result = await _service.GetAllAsync();


            return Ok(result);
        }

        [HttpGet("GetHabitacionById")]

        public async Task<IActionResult> GetById(int Id) 
        {
            var result = await _service.GetByIdAsync(Id);


            return Ok(result);
        }

        [HttpDelete("DeleteHabitacion")]

        public async Task<IActionResult> Delete(int Id, int IdUsuario) 
        {
            var result = await _service.DeleteAsync(Id, IdUsuario);


            return Ok(result);
        }

        [HttpPut("UpdateHabitacion")]

        public async Task<IActionResult> Update(UpdateHabitacionDto modelo) 
        {
            var result = await _service.UpdateAsync(modelo);


            return Ok(result);
        }
    }
}
