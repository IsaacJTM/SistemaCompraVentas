using System;

namespace ComprasVentas.DTOs;

public class CreatePermisoDto
{
    public string Nombre {get; set;} = string.Empty;
    public string? Recurso {get; set;}
    public string Accion {get; set;} = string.Empty;
}
