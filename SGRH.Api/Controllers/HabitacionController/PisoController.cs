using Microsoft.AspNetCore.Mvc;
using SGRH.Application.Interfaces.habitacion;
using SGRH.Domein.Models.Habitaciones;

namespace SGRH.Api.Controllers.HabitacionController
{
    [ApiController]
    [Route("Api/[controller]")]
    public class PisoController : Controller
    {
        private readonly IPisoService _service;

        public PisoController(IPisoService service)
        {
            _service = service;
        }

        [HttpPost("CreatePiso")]
        public async Task<IActionResult> Create(PisoModel model) 
        {
            var result = await _service.CreateAsync(model);

            if (!result.IsSucces)
                return BadRequest(result);


            return Ok(result);
        }

        [HttpGet("GetAllPiso")]

        public async Task<IActionResult> GetAll() 
        {
            var result = await _service.GetAllAsync();

            if (!result.IsSucces)
                return BadRequest(result);


            return Ok(result);
        }

        [HttpGet("GetPisoById")]
        public async Task<IActionResult> GetById(int Id) 
        {
            var result = await _service.GetByIdAsync(Id);

            if (!result.IsSucces)
                return BadRequest(result);


            return Ok(result);
        }

        [HttpDelete("DeletePiso")]
        public async Task<IActionResult> Delete(int Id, int IdUsuario) 
        {
            var result = await _service.DeleteAsync(Id, IdUsuario);

            if (!result.IsSucces)
                return BadRequest(result);


            return Ok(result);
        }

        [HttpPut("UpdatePiso")]
        public async Task<IActionResult> Update(PisoModel modelo) 
        {
            var result = await _service.UpdateAsync(modelo);

            if (!result.IsSucces)
                return BadRequest(result);


            return Ok(result);
        }
    }
}
