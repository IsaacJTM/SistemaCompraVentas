using ComprasVentas.DTOs;
using ComprasVentas.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace ComprasVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolControllers : ControllerBase
    {
        private readonly IRolServices _rolServices;

        public RolControllers(IRolServices rolServices)
        {
            _rolServices = rolServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _rolServices.GetAllAsync();
            return Ok(roles);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRolDto createRolDto)
        {
            await _rolServices.CreateAsync(createRolDto);
            return CreatedAtAction(nameof(GetAll), new { id = createRolDto.Nombre }, createRolDto);
        }
    }
}
