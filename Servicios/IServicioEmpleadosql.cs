using System;
using DapperWebApi.Modelos;

namespace DapperWebApi.Servicios;

public interface IServicioEmpleadosql
{
    public Task<IEnumerable<Empleado>> ListarEmpleados();
    public Task<Empleado> ObtenerEmpleado(string CodEmpleado);
    public Task CrearEmpleado(Empleado e);
    public Task ActualizarEmpleado(Empleado e);
    public Task EliminarEmpleado(string CodEmpleado);

}
