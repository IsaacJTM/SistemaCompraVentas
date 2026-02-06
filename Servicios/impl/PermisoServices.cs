using System;
using ComprasVentas.DTOs;
using ComprasVentas.Models;
using ComprasVentas.Repository;

namespace ComprasVentas.Servicios.impl;

public class PermisoServices : IPermisoServices
{
    private readonly PermisoRepository _permisoRepository;
    public PermisoServices(PermisoRepository permisoRepository)
    {
        _permisoRepository = permisoRepository;
    }   

    public async Task<List<Permiso>> GetAllAsync()
    {
        return await _permisoRepository.GetAllAsync();
    }

    public async Task<Permiso?> GetByIdAsync(int id)
    {
        return await _permisoRepository.GetByIdAsync(id);
    }

    public async Task CreateAsync(CreatePermisoDto permisoDto)
    {
        var permiso = new Permiso
        {
            Nombre = permisoDto.Nombre,
            Recurso = permisoDto.Recurso,
            Accion = permisoDto.Accion
        };
        await _permisoRepository.CreateAsync(permiso);
    }
    
}