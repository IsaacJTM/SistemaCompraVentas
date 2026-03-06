using System.Runtime.CompilerServices;
using ComprasVentas.Data;
using ComprasVentas.Models;
using Microsoft.EntityFrameworkCore;

namespace ComprasVentas.Repository;

public class UsuarioRepository
{
    private readonly AppDbContext _context;

    public UsuarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Usuario?> GetUsuarioByIdAsync(int Id)
    {
        return await _context.Usuarios
                        .Include(u => u.Persona)
                        .Include(u => u.Roles)
                        .FirstOrDefaultAsync(u => u.Id == Id);
    }

    public async Task<List<Usuario>> GetAllAsync()
    {
        return await _context.Usuarios
                        .Include(u => u.Persona)
                        .Include(u => u.Roles)
                        .ToListAsync();
    }

    public async Task CreateAsync(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Usuario usuario)
    {
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int Id)
    {
        var usuario = await GetUsuarioByIdAsync(Id);
        if(usuario != null)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistByCorreoAsync(string correo)
    {
        return await _context.Usuarios.AnyAsync(u => u.Correo == correo);
    }
}
