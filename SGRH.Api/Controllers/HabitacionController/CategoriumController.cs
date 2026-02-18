using Microsoft.AspNetCore.Mvc;
using SGRH.Application.DTOs.Habitacion.CategoriumDto;
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

        public async Task<IActionResult> Create(CreateCategoriumDto modelo) 
        {
            var result = await _service.CreateAsync(modelo);


            return Ok(result);
        }

        [HttpGet("GetAllCategorium")]

        public async Task<IActionResult> GetAll() 
        {
             var result =  await _service.GetAllAsync();


            return Ok(result);
        }

        [HttpGet("GetCategoriumById")]

        public async Task<IActionResult> GetById(int Id) 
        {
            var result = await _service.GetByIdAsync(Id);


            return Ok(result);
        }

        [HttpDelete("DeleteCategorium")]

        public async Task<IActionResult> Delete(int Id, int IdUsuario) 
        {
            var result = await _service.DeleteAsync(Id,IdUsuario);


            return Ok(result);
        }

        [HttpPut("UpdateCategorium")]

        public async Task<IActionResult> Update(UpdateCategoriumDto modelo) 
        {
            var result = await _service.UpdateAsync(modelo);


            return Ok(result);
        }
    }

}
