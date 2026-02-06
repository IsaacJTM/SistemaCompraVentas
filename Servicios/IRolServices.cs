using ComprasVentas.DTOs;
using ComprasVentas.Models;

namespace ComprasVentas.Servicios;

public interface IRolServices
{
    Task<List<Rol>> GetAllAsync();
    Task<Rol?> GetByIdAsync(int id);
    Task CreateAsync(CreateRolDto createRolDto);

}
