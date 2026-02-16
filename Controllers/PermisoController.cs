using ComprasVentas.DTOs;
using ComprasVentas.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace ComprasVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisoController(IPermisoServices permisoServices) : ControllerBase
    {
        private readonly IPermisoServices _permisoServices = permisoServices;
        [HttpGet]
        public async Task<ActionResult<List<PermisoResponseDto>>> GetAll()
        {
            var permisos = await _permisoServices.GetAllAsync();
            return Ok(permisos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PermisoResponseDto>> GetById(int id)
        {
            var permiso = await _permisoServices.GetByIdAsync(id);
            return permiso == null ? NotFound() : Ok(permiso);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreatePermisoDto createPermisoDto)
        {
            var permiso = await _permisoServices.CreateAsync(createPermisoDto);
            return CreatedAtAction(nameof(GetById), new { id = permiso.Id }, permiso);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _permisoServices.DeleteAsync(id);
            return Ok($"Permiso {id} eliminado correctamente");
        }
    }
}


