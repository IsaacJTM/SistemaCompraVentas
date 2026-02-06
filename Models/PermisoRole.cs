using System;

namespace ComprasVentas.Models;

public class PermisoRole
{
    public int PermisoId {get; set;}
    public Permiso Permiso {get; set;} = default!;
    public int RolId {get; set;}
    public Rol Rol {get; set;} = default!;

    public PermisoRole(){}

    public PermisoRole(int permisoId, int rolId)
    {
        PermisoId = permisoId;
        RolId = rolId;
    }
}
