namespace ComprasVentas.Models;

public class Rol
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion {get; set;}

    //Relación many to many
    //public ICollection<Permiso> Permisos {get; set;} = new List<Permiso>();
    private readonly List<PermisoRole> _permisoRoles = new();
    public IReadOnlyCollection<PermisoRole> PermisoRoles => _permisoRoles.AsReadOnly();
}
