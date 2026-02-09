namespace ComprasVentas.DTOs;

public record PermisoResponseDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Recurso { get; set; }
    public string Accion { get; set; } = string.Empty;
}
