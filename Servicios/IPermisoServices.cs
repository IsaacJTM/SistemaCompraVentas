using System;
using ComprasVentas.DTOs;
using ComprasVentas.Models;

namespace ComprasVentas.Servicios;

public interface IPermisoServices
{
    Task<List<Permiso>> GetAllAsync();
    Task<Permiso?> GetByIdAsync(int id);
    Task CreateAsync(CreatePermisoDto permisoDto);

}
