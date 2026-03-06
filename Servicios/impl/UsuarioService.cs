using System.Data;
using ComprasVentas.DTOs;
using ComprasVentas.Models;
using ComprasVentas.Repository;

namespace ComprasVentas.Servicios.impl;

public class UsuarioService
(
    UsuarioRepository usuarioRepository
) 
: IUsuarioService
{
    private readonly UsuarioRepository _usuarioRepository = usuarioRepository;

    public async Task<List<UsuarioResponseDto>> GetAllAsync()
    {
        try
        {
            var usuarios  = await _usuarioRepository.GetAllAsync();
            return usuarios.Select( user => MapToDto(user)).ToList();

        }catch(Exception ex){
            throw new Exception("Error al obtener Usuario: ", ex);
        }
    }

    public async Task<UsuarioResponseDto> GetByIdAsync(int id)
    {
        try
        {
            var usuario = await _usuarioRepository.GetUsuarioByIdAsync(id);
            if(usuario == null) throw new Exception($"Usuario con ID {id} no encontrado");
            return MapToDto(usuario); 

        }catch(Exception){
            throw;
        }

    }

    public async Task<UsuarioResponseDto> CreateAsync(CreateUsuarioDto dto)
    {

       var existe = await _usuarioRepository.ExistByCorreoAsync(dto.Correo);
       if(existe) throw new Exception("Ya existe un usuario con ese correo");
       
       var usuario = new Usuario
       {
            Nombre = dto.Nombre,
            Correo = dto.Correo,
            //TODO ADD PASSWORD HASHIN
            Password = dto.Password,
            Persona = new Persona
            {
                Nombres = dto.Nombres,
                Apellidos = dto.Apellidos,
                FechaNacimiento = DateTime.ParseExact(dto.FechaNacimiento, "dd/MM/yyyy", null),
                Genero = dto.Genero,
                Telefono = dto.Telefono,
                Direccion = dto.Direccion,
                Nacionalidad = dto.Nacionalidad
            }
           
       };
       await _usuarioRepository.CreateAsync(usuario);
       return MapToDto(usuario);
    }

    public async Task<UsuarioResponseDto> UpdateAsync(int id, CreateUsuarioDto dto)
    {
        var usuario = await _usuarioRepository.GetUsuarioByIdAsync(id);
        if(usuario == null) throw new Exception("Usuario no encontrado");
        usuario.Nombre = dto.Nombre;
        usuario.Correo = dto.Correo;
        usuario.Password = dto.Password;
        if(usuario.Persona != null)
        {
            usuario.Persona.Nombres = dto.Nombres;
            usuario.Persona.Apellidos = dto.Apellidos;
            usuario.Persona.FechaNacimiento = DateTime.ParseExact(dto.FechaNacimiento, "dd/MM/yyyy", null);
            usuario.Persona.Genero = dto.Genero;
            usuario.Persona.Telefono = dto.Telefono;
            usuario.Persona.Direccion = dto.Direccion;
            usuario.Persona.Nacionalidad = dto.Nacionalidad;
        };
        await _usuarioRepository.UpdateAsync(usuario);
        return MapToDto(usuario);
    }

    public async Task DeleteAsync(int id)
    {
        var usuario = await _usuarioRepository.GetUsuarioByIdAsync(id);
        if(usuario == null) throw new Exception("Usuario no encontrado");
        await _usuarioRepository.DeleteAsync(id);
    }

    //Creamos un mapper
    private UsuarioResponseDto MapToDto(Usuario usuario)
    {
        return new UsuarioResponseDto
        {
            Id = usuario.Id,
            Nombre =  usuario.Nombre,
            Correo = usuario.Correo,
            Nombres = usuario.Persona?.Nombres ?? string.Empty,
            Apellidos = usuario.Persona?.Apellidos ?? string.Empty,
            FechaNacimiento = usuario.Persona?.FechaNacimiento.ToString("dd/mm/yyyy") ?? string.Empty,
            Genero = usuario.Persona?.Genero,
            Telefono = usuario.Persona?.Telefono,
            Direccion = usuario.Persona?.Direccion,
            Nacionalidad = usuario.Persona?.Nacionalidad
        };
    }
}


//Debemos mejorar en la generaicón de ddocumento de al escritura. 