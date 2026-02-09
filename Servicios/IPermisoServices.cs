using System;
using ComprasVentas.DTOs;
using ComprasVentas.Models;

namespace ComprasVentas.Servicios;

public interface IPermisoServices
{
    Task<List<PermisoResponseDto>> GetAllAsync();
    Task<PermisoResponseDto?> GetByIdAsync(int id);
    Task<PermisoResponseDto> CreateAsync(CreatePermisoDto permisoDto);

}
