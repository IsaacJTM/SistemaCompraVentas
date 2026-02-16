using ComprasVentas.DTOs;
using ComprasVentas.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace ComprasVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolControllers(IRolServices rolServices) : ControllerBase
    {
        private readonly IRolServices _rolServices = rolServices;

        [HttpGet]
        public async Task<ActionResult<List<RolResponseDto>>> GetAll()
        {
            var roles = await _rolServices.GetAllAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RolResponseDto>> GetById(int id)
        {
            var rol = await _rolServices.GetByIdAsync(id);
            if(rol == null) return NotFound();
            return Ok(rol);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateRolDto createRolDto)
        {
            var rol = await _rolServices.CreateAsync(createRolDto);
            return CreatedAtAction(nameof(GetById), new { id = rol.Id }, rol);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RolResponseDto>> Update(int id, [FromBody] CreateRolDto updateRolDto)
        {
            var rol = await _rolServices.UpdateAsync(id, updateRolDto);
            return Ok(rol);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _rolServices.DeleteAsync(id);
            return Ok("Rol eliminado correctamente");
        }
    }
}
