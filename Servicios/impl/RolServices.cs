using ComprasVentas.Builder;
using ComprasVentas.DTOs;
using ComprasVentas.Models;
using ComprasVentas.Repository;

namespace ComprasVentas.Servicios.impl;

public class RolServices
(
    RolRepository rolRepository, 
    PermisoRepository permisoRepository
) : IRolServices
{
    private readonly RolRepository _rolRepository = rolRepository;
    private readonly PermisoRepository _permisoRepository = permisoRepository;

    public async Task<List<RolResponseDto>> GetAllAsync()
    {
        var roles = await _rolRepository.GetAllAsync();
        return [.. roles.Select(r => new RolResponseDto
        {
            Id = r.Id,
            Nombre = r.Nombre,
            Descripcion = r.Descripcion,
            Permisos = r.PermisoRoles.Select(pr => new PermisoResponseDto{
                Id = pr.Permiso.Id,
                Nombre = pr.Permiso.Nombre
            }).ToList()
        })];
    }

    public async Task<RolResponseDto?> GetByIdAsync(int id)
    {
        var rol = await _rolRepository.GetByIdAsync(id);
        if (rol == null) throw new Exception($"Rol con ID {id} no encontrado");
        return new RolResponseDto
        {
           Id = rol.Id,
            Nombre = rol.Nombre,
            Descripcion = rol.Descripcion,
            Permisos = rol.PermisoRoles.Select(pr => new PermisoResponseDto{
                Id = pr.Permiso.Id,
                Nombre = pr.Permiso.Nombre
            }).ToList() 
        };
    }

    public async Task<RolResponseDto> CreateAsync(CreateRolDto dto)
    {
        var permisos = new List<Permiso>();
        foreach (var permisoId in dto.PermisoIds)
        {
            var permiso = await _permisoRepository.GetByIdAsync(permisoId);
            //if(permiso == null) throw new Exception($"Permiso con ID {permisoId} no encontrado");
            if(permiso != null) permisos.Add(permiso);
        }
        var rol = new RolBuilder()
            .WithNombre(dto.Nombre)
            .WithDescripcion(dto.Descripcion)
            .WithPermisos(permisos)
            .Build();
        await _rolRepository.CreateAsync(rol);
        return new RolResponseDto
        {
            Id = rol.Id,
            Nombre = rol.Nombre,
            Descripcion = rol.Descripcion,
            Permisos = rol.PermisoRoles.Select(pr => new PermisoResponseDto{
                Id = pr.Permiso.Id,
                Nombre = pr.Permiso.Nombre
            }).ToList()
        };
    }
    public async Task<RolResponseDto> UpdateAsync(int id, CreateRolDto dto)
    {
        var rol = await _rolRepository.GetByIdAsync(id);
        if(rol == null) throw new Exception($"Rol con ID {id} no encontrado");
        var permisos = new List<Permiso>();
        foreach (var permisoId in dto.PermisoIds)
        {
            var permiso = await _permisoRepository.GetByIdAsync(permisoId);
            if(permiso != null) permisos.Add(permiso);
        }
        rol.Nombre = dto.Nombre;
        rol.Descripcion = dto.Descripcion;
        rol.ClearPermisos();
        var permisosIds = permisos.Select(p => p.Id);
        rol.AddPermisos(permisosIds);
        await _rolRepository.UpdateAsync(rol);
        return new RolResponseDto
        {
            Id = rol.Id,
            Nombre = rol.Nombre,
            Descripcion = rol.Descripcion,
            Permisos = rol.PermisoRoles.Select(pr => new PermisoResponseDto{
                Id = pr.Permiso.Id,
                Nombre = pr.Permiso.Nombre
            }).ToList()
        };
    }

    public async Task DeleteAsync(int id)
    {
        await _rolRepository.DeleteAsync(id);
    }

}
