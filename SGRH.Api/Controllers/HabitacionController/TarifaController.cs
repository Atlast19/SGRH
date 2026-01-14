using Microsoft.AspNetCore.Mvc;
using SGRH.Application.Interfaces.habitacion;
using SGRH.Domein.Models.Habitaciones;

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
        public async Task<IActionResult> create(TarifaDTO modelo)
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

        [HttpDelete("Delete")]

        public async Task<IActionResult> Delete(int id, int IdUsuario)
        {
            var result = await _service.DeleteAsync(id, IdUsuario);

            if (!result.IsSucces)
                return BadRequest(result);


            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(TarifaDTO modelo) 
        {
            var result = await _service.UpdateAsync(modelo);

            if (!result.IsSucces)
                return BadRequest(result);


            return Ok(result);
        }


    }
}
