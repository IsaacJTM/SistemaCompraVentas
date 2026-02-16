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

    public async Task<List<PermisoResponseDto>> GetAllAsync()
    {
        var permisos = await _permisoRepository.GetAllAsync();
        return permisos.Select(p => new PermisoResponseDto
        {
            Id = p.Id,
            Nombre = p.Nombre,
            Recurso = p.Recurso,
            Accion = p.Accion
        }).ToList();
    }
    public async Task<PermisoResponseDto?> GetByIdAsync(int id)
    {
        var permiso = await _permisoRepository.GetByIdAsync(id);
        if(permiso == null) return null;
        return new PermisoResponseDto
        {
            Id = permiso.Id,
            Nombre = permiso.Nombre,
            Recurso = permiso.Recurso,
            Accion = permiso.Accion
        };
    }

    public async Task<PermisoResponseDto> CreateAsync(CreatePermisoDto permisoDto)
    {
        var ExistingPermiso = await _permisoRepository.FindByNombreAsync(permisoDto.Nombre);
        if(ExistingPermiso != null) throw new Exception($"Ya existe un permiso con el nombre {permisoDto.Nombre}");

        var permiso = new Permiso
        {
          Nombre = permisoDto.Nombre,
          Recurso = permisoDto.Recurso,
          Accion = permisoDto.Accion  
        };
                
        await _permisoRepository.CreateAsync(permiso);
        return new PermisoResponseDto
        {
            Id = permiso.Id,
            Nombre = permiso.Nombre,
            Recurso = permiso.Recurso,
            Accion = permiso.Accion
        };
    }

    public async Task DeleteAsync(int id)
    {
        await _permisoRepository.DeleteAsync(id);
    }
}