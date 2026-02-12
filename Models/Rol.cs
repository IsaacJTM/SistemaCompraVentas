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

    //Método para agregar un permisos al Rol (mantiene encapsulado el acceso a la lista de permisos)
    public void AddPermiso(int permisoId)
    {
        if(_permisoRoles.Any(pr => pr.PermisoId == permisoId)) return; //Evitar agregar permisos duplicados
        _permisoRoles.Add(new PermisoRole(permisoId, this.Id));
    }

    public void AddPermisos(IEnumerable<int>  permisosIds)
    {
        foreach(var permisoId in permisosIds)
        {
            AddPermiso(permisoId);
        }
    }

    public void ClearPermisos()
    {
        _permisoRoles.Clear();
    }


}
