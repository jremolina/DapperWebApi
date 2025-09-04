using System;

namespace DapperWebApi.Modelos;

public class Empleado
{
    public int Id { get; init; }
    public required string Nombre { get; set; } 
    public required string CodEmpleado { get; set; } 
    public required string Email { get; set; } 
    public int Edad { get; set; }
    public DateTime fechaIngreso { get; set; }
    public DateTime? fechaRetiro { get; set; }
}