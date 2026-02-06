namespace ComprasVentas.Models;

public class Permiso
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Recurso { get; set; }
    public string Accion { get; set; }  = string.Empty; //Empty es vacio.

    //Relación many to many
    //public ICollection<Rol> Roles {get; set;} = new List<Rol>();

    private readonly List<PermisoRole> _permisoRoles = new();
    public IReadOnlyCollection<PermisoRole> PermisoRoles => _permisoRoles.AsReadOnly();
}
