using ComprasVentas.Models;

namespace ComprasVentas.Builder;

public class RolBuilder
{//Un Builder construir un objeto a partir de otro, en este caso un Rol a partir de un CreateRolDto
    private readonly Rol _rol = new Rol();
    public RolBuilder WithNombre(string nombre)
    {
        _rol.Nombre = nombre;
        return this;
    }

    public RolBuilder WithDescripcion(string? descripcion)
    {
        _rol.Descripcion = descripcion;
        return this;
    }

    public RolBuilder WithPermisos(List<Permiso> permisos)
    {
        if(permisos != null && permisos.Any())
        {
            var permisoIds = permisos.Select(p => p.Id);
            _rol.AddPermisos(permisoIds);
        };
        return this;
    }

    public Rol Build() => _rol;

}
