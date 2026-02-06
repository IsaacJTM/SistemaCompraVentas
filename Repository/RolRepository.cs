using ComprasVentas.Data;
using ComprasVentas.Models;
using Microsoft.EntityFrameworkCore;

namespace ComprasVentas.Repository;

public class RolRepository
{
    private readonly AppDbContext _context;

    public RolRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Rol>> GetAllAsync()
    {
        return await _context.Roles.Include(r => r.PermisoRoles).ToListAsync();
    }

    public async Task<Rol?> GetByIdAsync(int id)
    {
        return await _context.Roles.Include(r => r.PermisoRoles).FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task CreateAsync(Rol rol)
    {
       _context.Roles.Add(rol);
       await _context.SaveChangesAsync();  
    }
}
