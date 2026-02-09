namespace ComprasVentas.DTOs;
public record CreatePermisoDto
{
    public string Nombre {get; set;} = string.Empty;
    public string? Recurso {get; set;}
    public string Accion {get; set;} = string.Empty;
}
