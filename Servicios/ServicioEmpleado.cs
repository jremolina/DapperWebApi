using System;
using System.Runtime.CompilerServices;
using DapperWebApi.Modelos;

namespace DapperWebApi.Servicios;

public class ServicioEmpleado : IServicioEmpleado
{

    private readonly List<Empleado> ListaEmpleados = new()
    {
        new Empleado{Id = 1, Nombre = "Jhonny", CodEmpleado ="A001", Email = "Correo1@correo.com", Edad = 45,fechaIngreso = DateTime.Now, fechaRetiro = null },
        new Empleado{Id = 2, Nombre = "Alejandro", CodEmpleado ="A002", Email = "Correo2@correo.com", Edad = 6,fechaIngreso = DateTime.Now,fechaRetiro = null  },
        new Empleado{Id = 3, Nombre = "Elvira", CodEmpleado ="A003", Email = "Correo3@correo.com", Edad = 42,fechaIngreso = DateTime.Now ,fechaRetiro = null },
        new Empleado{Id = 4, Nombre = "Leyla", CodEmpleado ="A004", Email = "Correo4@correo.com", Edad = 65,fechaIngreso = DateTime.Now ,fechaRetiro = null }

    };
    public IEnumerable<Empleado> GetEmpleados()
    {
        return ListaEmpleados;

    }

    public Empleado GetEmpleado(string CodEmpleado)
    {
        return ListaEmpleados.Where(e => e.CodEmpleado == CodEmpleado).SingleOrDefault();
    }

    public void PostEmpleado(Empleado e)
    {
        ListaEmpleados.Add(e);

    }

    public void PutEmpleado(Empleado e)
    {
        int posicion = ListaEmpleados.FindIndex(existe => existe.Id == e.Id);
        if (posicion != -1)
        {
            ListaEmpleados[posicion] = e;
        }
    }

    public void DeleteEmpleado(string CodEmpleado)
    {
        int posicion = ListaEmpleados.FindIndex(existe => existe.CodEmpleado == CodEmpleado);
        if (posicion != -1)
        {
            ListaEmpleados.RemoveAt(posicion);
        }
    }









}
