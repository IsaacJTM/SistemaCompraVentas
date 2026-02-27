using System.ComponentModel.DataAnnotations;
using ComprasVentas.Models;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ComprasVentas.DTOs;

public class CreateUsuarioDto
{
    //Restricciones o Validaciones 
    [Required(ErrorMessage = "El Nombre es obligatorio")]
    [StringLength(50)]
    public string Nombre {get; set;} = string.Empty;
    [Required(ErrorMessage = "El correo es obligatorio")]
    [EmailAddress]
    [StringLength(50)]
    public string Correo {get; set;} = string.Empty;
    [Required]
    [StringLength(100, MinimumLength = 8)]
    public string Password {get; set;} = string.Empty;
    
    //Datos de Persona
    [Required (ErrorMessage = "Los nombres son requeridos")]
    [StringLength(100)]
    public string Nombres {get; set;} = string.Empty;
    public string Apellidos {get; set;} = string.Empty;
    [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
    [RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$", 
        ErrorMessage = "El formato debe ser dd/mm/yyyy.")]
    public string FechaNacimiento {get; set;} 
    public string? Genero {get; set;}
    public string? Telefono {get; set;} 
    public string? Direccion {get; set;} 
    public string ? Nacionalidad {get;set;}

}
