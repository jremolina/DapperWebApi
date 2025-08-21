using System;
using DapperWebApi.Modelos;

namespace DapperWebApi.Servicios;

public interface IServicioEmpleado
{
    public IEnumerable<Empleado> GetEmpleados();
    public Empleado GetEmpleado(string CodEmpleado);

    public void PostEmpleado(Empleado e);

    public void PutEmpleado(Empleado e);

    public void DeleteEmpleado(string CodEmpleado);



}
