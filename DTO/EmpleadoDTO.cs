using System;
using System.ComponentModel.DataAnnotations;

namespace DapperWebApi.DTO;

public class EmpleadoDTO
{
    [Required(ErrorMessage = "Campo Requerido")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "Campo Requerido")]
    [MaxLength(4, ErrorMessage = "Maximo Cuatro digitos")]
    public string CodEmpleado { get; set; }

    [Required(ErrorMessage = "Campo Requerido")]
    [EmailAddress(ErrorMessage = "Formato Incorrecto")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Campo Requerido")]
    [Range(16, 100, ErrorMessage = "Edad entre 16  y  100")]
    public int Edad { get; set; }

}
