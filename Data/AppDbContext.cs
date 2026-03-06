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
    public DbSet<Persona> Personas {get; set;}
    public DbSet<Usuario> Usuarios {get; set;}

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
        
        modelBuilder.Entity<Usuario>()
            .HasMany(r => r.Roles)
            .WithMany(p => p.Usuarios)
            .UsingEntity(q=>q.ToTable("usuario_rol"));

        modelBuilder.Entity<Usuario>()
            .HasOne(u => u.Persona)
            .WithOne(p => p.Usuario)
            .HasForeignKey<Persona>(p => p.Id);

        //Para las restricciones 
        modelBuilder.Entity<Usuario>(e =>
        {
            e.Property(u => u.Nombre).IsRequired().HasMaxLength(50);
            e.Property(u => u.Correo).IsRequired().HasMaxLength(255);
            e.Property(u => u.Password).IsRequired().HasMaxLength(255);
        });

        modelBuilder.Entity<Persona>( e =>
        {
           e.Property(p => p.Nombres).IsRequired().HasMaxLength(100);
           e.Property(p => p.Apellidos).IsRequired().HasMaxLength(100);
           e.Property(p => p.Genero).HasMaxLength(20);
           e.Property(p => p.Telefono).HasMaxLength(20);
           e.Property(p => p.Direccion).HasMaxLength(255);
           e.Property(p => p.Nacionalidad).HasMaxLength(50);
        });

        modelBuilder.Entity<Permiso>(e =>
        {
           e.Property(p => p.Nombre).IsRequired().HasMaxLength(100);
           e.Property(p => p.Recurso).HasMaxLength(100);
           e.Property(p => p.Accion).IsRequired().HasMaxLength(100);
        });

        modelBuilder.Entity<Rol>(e =>
        {
           e.Property(r => r.Nombre).IsRequired().HasMaxLength(100);
           e.Property(r => r.Descripcion).HasMaxLength(255);
        });
    }
}
