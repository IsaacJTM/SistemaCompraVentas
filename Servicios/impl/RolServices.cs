using ComprasVentas.DTOs;
using ComprasVentas.Models;
using ComprasVentas.Repository;

namespace ComprasVentas.Servicios.impl;

public class RolServices : IRolServices
{
    private readonly RolRepository _rolRepository;

    public RolServices(RolRepository rolRepository)
    {
        _rolRepository = rolRepository;
    }

    public async Task CreateAsync(CreateRolDto createRolDto)
    {

        await _rolRepository.CreateAsync(new Rol
        {
            Nombre = createRolDto.Nombre,
            Descripcion = createRolDto.Descripcion
        });
    }

    public Task<List<Rol>> GetAllAsync()
    {
       return _rolRepository.GetAllAsync();
    }

    public Task<Rol?> GetByIdAsync(int id)
    {
        return _rolRepository.GetByIdAsync(id);
    }

}
