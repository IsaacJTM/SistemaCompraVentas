using ComprasVentas.Models;
using Microsoft.EntityFrameworkCore;

namespace ComprasVentas.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Rol> Roles { get; set; }
    public DbSet<Permiso> Permisos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Definimos la clave primaria compuesta para la tabla intermedia
        modelBuilder.Entity<PermisoRole>().HasKey(pr => new {pr.PermisoId, pr.RolId});
        //Configuramos las relaciones con la tabla Permiso
        modelBuilder.Entity<PermisoRole>()
            .HasOne(pr => pr.Permiso)
            .WithMany(p => p.PermisoRoles)
            .HasForeignKey(pr => pr.PermisoId);
        //Configuramos las relaciones con la tabla Rol
        modelBuilder.Entity<PermisoRole>()
            .HasOne(pr => pr.Rol)
            .WithMany(r => r.PermisoRoles)
            .HasForeignKey(pr => pr.RolId);
        

        //Podemos aumentar restricciones y configuraciones aquí si es necesario (Fluent API)
        modelBuilder.Entity<Rol>()
            .HasIndex(r => r.Nombre)
            .IsUnique();
    }
}
