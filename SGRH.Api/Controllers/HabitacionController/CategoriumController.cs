using Microsoft.AspNetCore.Mvc;
using SGRH.Application.DTOs.Habitacion;
using SGRH.Application.Interfaces.habitacion;

namespace SGRH.Api.Controllers.HabitacionController
{
    [ApiController]
    [Route("Api/[controller]")]
    public class CategoriumController : Controller
    {
        private readonly ICategoriumService _service;

        public CategoriumController(ICategoriumService service)
        {
            _service = service;
        }

        [HttpPost("CreateCategorium")]

        public async Task<IActionResult> Create(CategoriumDTO modelo) 
        {
            var result = await _service.CreateAsync(modelo);

            if (!result.IsSucces)
                return BadRequest(result);


            return Ok(result);
        }

        [HttpGet("GetAllCategorium")]

        public async Task<IActionResult> GetAll() 
        {
            var result =  await _service.GetAllAsync();

            if (!result.IsSucces)
                return BadRequest(result);


            return Ok(result);
        }

        [HttpGet("GetCategoriumById")]

        public async Task<IActionResult> GetById(int Id) 
        {
            var result = await _service.GetByIdAsync(Id);

            if (!result.IsSucces)
                return BadRequest(result);


            return Ok(result);
        }

        [HttpDelete("DeleteCategorium")]

        public async Task<IActionResult> Delete(int Id, int IdUsuario) 
        {
            var result = await _service.DeleteAsync(Id,IdUsuario);

            if (!result.IsSucces)
                return BadRequest(result);


            return Ok(result);
        }

        [HttpPut("UpdateCategorium")]

        public async Task<IActionResult> Update(CategoriumDTO modelo) 
        {
            var result = await _service.UpdateAsync(modelo);

            if (!result.IsSucces)
                return BadRequest(result);


            return Ok(result);
        }
    }

}
