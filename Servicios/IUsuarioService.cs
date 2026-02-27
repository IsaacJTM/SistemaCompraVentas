using ComprasVentas.DTOs;

namespace ComprasVentas.Servicios;

public interface IUsuarioService
{
    Task<List<UsuarioResponseDto>> GetAllAsync();
    Task<UsuarioResponseDto> GetByIdAsync(int id);
    Task<UsuarioResponseDto> CreateAsync(CreateUsuarioDto dto);
    Task<UsuarioResponseDto> UpdateAsync(int id, CreateUsuarioDto dto);
    Task DeleteAsync(int id);

}
