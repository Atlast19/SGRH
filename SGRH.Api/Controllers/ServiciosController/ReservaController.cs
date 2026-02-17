using Microsoft.AspNetCore.Mvc;
using SGRH.Application.DTOs.Reserva.ReservaDto;
using SGRH.Application.Interfaces.Services;
using System.Diagnostics.CodeAnalysis;

namespace SGRH.Api.Controllers.ServiciosController
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ReservaController : Controller
    {
        private readonly IReservaServices _service;

        public ReservaController(IReservaServices service)
        {
            _service = service;
        }

        [HttpPost("CreateReserva")]

        public async Task<IActionResult> Create(CreateReservaDto modelo) 
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
            if (Id <= 0)
                return NotFound("No se Encontro la Reserva Solicitada");

            var result = await _service.GetByIdAsync(Id);

            if (result == null)
                return NotFound("No se Encontro la Reserva Solicitada");

            return Ok(result);
        }

        [HttpDelete("DeleteReserva")]

        public async Task<IActionResult> Delete(int Id, int IdUsuario) 
        {
            if (Id <= 0 || IdUsuario <= 0)
                return NotFound("No se Encontro la Reserva a Eliminar");

            var result = await _service.DeleteAsync(Id, IdUsuario);

            if (result == null)
                return NotFound("No se Encontro la Reserva a Eliminar");

            return Ok(result);
        }

        [HttpPut("UpdateReserva")]

        public async Task<IActionResult> Update(UpdateReservaDto modelo) 
        {
            var result = await _service.UpdateAsync(modelo);


            return Ok(result);
        }
    }
}
