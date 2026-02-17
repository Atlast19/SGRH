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
            if (Id <= 0)
                return NotFound("No se Encontro la Habitacion Solicitada");

            var result = await _service.GetByIdAsync(Id);

            if (result == null)
                return NotFound("No se Encontro la Habitacion Solicitada");

            return Ok(result);
        }

        [HttpDelete("DeleteHabitacion")]

        public async Task<IActionResult> Delete(int Id, int IdUsuario) 
        {
            if (Id <= 0 || IdUsuario <= 0)
                return NotFound("No se Encontro la Habitacion a Eliminar");

            var result = await _service.DeleteAsync(Id, IdUsuario);

            if (result == null)
                return NotFound("No se Encontro la Habitacion a Eliminar");

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
