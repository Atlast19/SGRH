using Microsoft.AspNetCore.Mvc;
using SGRH.Application.DTOs.Habitacion.PisoDto;
using SGRH.Application.Interfaces.habitacion;


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
        public async Task<IActionResult> Create(CreatePisoDto model) 
        {
            var result = await _service.CreateAsync(model);


            return Ok(result);
        }

        [HttpGet("GetAllPiso")]

        public async Task<IActionResult> GetAll() 
        {
            var result = await _service.GetAllAsync();


            return Ok(result);
        }

        [HttpGet("GetPisoById")]
        public async Task<IActionResult> GetById(int Id) 
        {
            if (Id <= 0)
                return NotFound("No se Encontro el Piso Solicitado");

            var result = await _service.GetByIdAsync(Id);

            if (result == null)
                return NotFound("No se Encontro el Piso Solicitado");

            return Ok(result);
        }

        [HttpDelete("DeletePiso")]
        public async Task<IActionResult> Delete(int Id, int IdUsuario) 
        {
            if (Id <= 0 || IdUsuario <= 0)
                return NotFound("No se Encontro el Piso a Eliminar");

            var result = await _service.DeleteAsync(Id, IdUsuario);

            if (result == null)
                return NotFound("No se Encontro el Piso a Eliminar");

            return Ok(result);
        }

        [HttpPut("UpdatePiso")]
        public async Task<IActionResult> Update(UpdatePisoDto modelo) 
        {
            var result = await _service.UpdateAsync(modelo);


            return Ok(result);
        }
    }
}
