using System;
using DapperWebApi.DTO;
using DapperWebApi.Modelos;

namespace DapperWebApi;

public static class Utilidades
{
    public static EmpleadoDTO convertirADTO(this Empleado e)
    {
        if (e != null)
        {
            return new EmpleadoDTO()
            {
                Nombre = e.Nombre,
                CodEmpleado = e.CodEmpleado,
                Email = e.Email,
                Edad = e.Edad
            };

        }
        return null;
    }

}
