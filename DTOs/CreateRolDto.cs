namespace ComprasVentas.DTOs;

public record CreateRolDto
{
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion {get; set;}
}
