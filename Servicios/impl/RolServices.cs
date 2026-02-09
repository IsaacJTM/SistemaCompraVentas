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
        if (rol == null) return null;
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
            if(permiso == null) throw new Exception($"Permiso con ID {permisoId} no encontrado");
            permisos.Add(permiso);
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
    public Task UpdateAsync(int id, CreateRolDto dto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

}
