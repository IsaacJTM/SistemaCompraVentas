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

    public Task<PermisoResponseDto> CreateAsync(CreatePermisoDto permisoDto)
    {
        throw new NotImplementedException();
    }

    public Task<List<PermisoResponseDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<PermisoResponseDto?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}