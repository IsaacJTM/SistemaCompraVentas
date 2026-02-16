using ComprasVentas.Data;
using ComprasVentas.Models;
using Microsoft.EntityFrameworkCore;

namespace ComprasVentas.Repository;

public class PermisoRepository(AppDbContext context)
{
    //Inyección de dependencias por clase
    private readonly AppDbContext  _context = context;

    public async Task<List<Permiso>> GetAllAsync()
    {
        return await _context.Permisos.ToListAsync();
    }

    public async Task<Permiso?> GetByIdAsync(int id)
    {
        return await _context.Permisos.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task CreateAsync(Permiso permiso)
    {
        _context.Permisos.Add(permiso);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var permiso = await GetByIdAsync(id);
        if(permiso != null)
        {
            _context.Permisos.Remove(permiso);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Permiso?> FindByNombreAsync(string nombre)
    {
        return await _context.Permisos.Where(p => p.Nombre == nombre).FirstOrDefaultAsync();
    }

}
