using Microsoft.AspNetCore.Mvc;
using SGRH.Application.DTOs.Habitacion.PisoDto;
using SGRH.Application.DTOs.Habitacion.TarifaDto;
using SGRH.Application.Interfaces.habitacion;

namespace SGRH.Api.Controllers.HabitacionController
{
    [ApiController]
    [Route("Api/[controller]")]
    public class TarifaController : Controller
    {
        private readonly ITarifaService _service;

        public TarifaController(ITarifaService service)
        {
            _service = service;
        }

        [HttpPost("CreateTarifa")]
        public async Task<IActionResult> create(CreateTarifaDto modelo)
        {
            var result = await _service.CreateAsync(modelo);


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
            var result = await _service.GetByIdAsync(Id);


            return Ok(result);
        }

        [HttpDelete("Delete")]

        public async Task<IActionResult> Delete(int id, int IdUsuario)
        {
            var result = await _service.DeleteAsync(id, IdUsuario);


            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateTarifaDto modelo) 
        {
            var result = await _service.UpdateAsync(modelo);


            return Ok(result);
        }


    }
}
