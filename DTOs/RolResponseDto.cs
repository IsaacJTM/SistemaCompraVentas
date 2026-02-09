namespace ComprasVentas.DTOs;

public record RolResponseDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public List<PermisoResponseDto> Permisos { get; set; } = new List<PermisoResponseDto>();

}
