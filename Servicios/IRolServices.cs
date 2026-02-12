using ComprasVentas.DTOs;

namespace ComprasVentas.Servicios;

public interface IRolServices
{
    Task<List<RolResponseDto>> GetAllAsync();
    Task<RolResponseDto?> GetByIdAsync(int id);
    Task<RolResponseDto> CreateAsync(CreateRolDto dto);
    Task<RolResponseDto> UpdateAsync(int id, CreateRolDto dto);
    Task DeleteAsync(int id);

}
