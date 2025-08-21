using System;
using DapperWebApi.Modelos;

namespace DapperWebApi.Servicios;

public interface IServicioEmpleadosql
{
    public IEnumerable<Empleado> ListarEmpleados();
    public Empleado ObtenerEmpleado(string CodEmpleado);
    public void CrearEmpleado(Empleado e);
    public void ActualizarEmpleado(Empleado e);
    public void EliminarEmpleado(string CodEmpleado);

}
