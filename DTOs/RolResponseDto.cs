using System;

namespace ComprasVentas.DTOs;

public record RolResponseDto
{
    public int Id { get; init; }
    public string Nombre { get; init; } = string.Empty;
    public string? Descripcion { get; init; }

}
