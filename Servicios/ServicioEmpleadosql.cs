using System;
using System.Data;
using Dapper;

// using System.Data.SqlClient;
using DapperWebApi.Modelos;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;

namespace DapperWebApi.Servicios;

public class ServicioEmpleadosql : IServicioEmpleadosql
{
    private string CadenaConexion;
    private ILogger<ServicioEmpleadosql> log;

    public ServicioEmpleadosql(ConexionBaseDatos conex, ILogger<ServicioEmpleadosql> logger)
    {
        CadenaConexion = conex.CadenaConexionSQL;
        this.log = logger;
    }
    private SqlConnection conexion()
    {
        return new SqlConnection(CadenaConexion);
    }

    public async Task<Empleado> ObtenerEmpleado(string CodEmpleado)
    {
        //throw new NotImplementedException();
        SqlConnection sqlConexion = conexion();
        Empleado? e = null;

        try
        {
            sqlConexion.Open();
            var param = new DynamicParameters();
            param.Add("@CodEmpleado", CodEmpleado, DbType.String, ParameterDirection.Input, 4);
            e = await sqlConexion.QueryFirstOrDefaultAsync<Empleado>("ObtenerEmpleado", param, commandType: CommandType.StoredProcedure);

            if (e == null)
            {
                throw new KeyNotFoundException($"No se encontró un empleado con el código '{CodEmpleado}'.");
            }
        }
        catch (Exception ex)
        {
            log.LogError("Error : " + ex.ToString());
            throw new Exception("se produjo un error al obtener empleado" + ex.Message);
        }
        finally
        {
            sqlConexion.Close();
            sqlConexion.Dispose();
        }
        return e;
    }

    public async Task<IEnumerable<Empleado>> ListarEmpleados()
    {
        SqlConnection sqlConexion = conexion();
        List<Empleado> empleados = new List<Empleado>();

        try
        {
            sqlConexion.Open();
            var r = await sqlConexion.QueryAsync<Empleado>("ObtenerEmpleado", commandType: CommandType.StoredProcedure);
            empleados = r.ToList();
        }
        catch (Exception ex)
        {
            log.LogError("Error : " + ex.ToString());
            throw new Exception("se produjo un error al obtener empleadoS" + ex.Message);
        }
        finally
        {
            sqlConexion.Close();
            sqlConexion.Dispose();
        }
        return empleados;
    }

    public async Task CrearEmpleado(Empleado e)
    {
        SqlConnection sqlConexion = conexion();

        try
        {
            sqlConexion.Open();
            var param = new DynamicParameters();
            param.Add("@Nombre", e.Nombre, DbType.String, ParameterDirection.Input, 500);
            param.Add("@CodEmpleado", e.CodEmpleado, DbType.String, ParameterDirection.Input, 4);
            param.Add("@Email", e.Email, DbType.String, ParameterDirection.Input, 255);
            param.Add("@Edad", e.Edad, DbType.Int32, ParameterDirection.Input);
            param.Add("@fechaIngreso", e.fechaIngreso, DbType.DateTime, ParameterDirection.Input);
            await sqlConexion.ExecuteScalarAsync("CrearEmpleado", param, commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            log.LogError("Error : " + ex.ToString());
            throw new Exception("se produjo un error al insertar el registro" + ex.Message);
        }
        finally
        {
            sqlConexion.Close();
            sqlConexion.Dispose();
        }

    }

    public async Task ActualizarEmpleado(Empleado e)
    {
        SqlConnection sqlConexion = conexion();

        try
        {
            sqlConexion.Open();
            var param = new DynamicParameters();
            param.Add("@Nombre", e.Nombre, DbType.String, ParameterDirection.Input, 500);
            param.Add("@CodEmpleado", e.CodEmpleado, DbType.String, ParameterDirection.Input, 4);
            param.Add("@Email", e.Email, DbType.String, ParameterDirection.Input, 255);
            param.Add("@Edad", e.Edad, DbType.Int32, ParameterDirection.Input);
            await sqlConexion.ExecuteScalarAsync("ActualizarEmpleado", param, commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            log.LogError("Error : " + ex.ToString());
            throw new Exception("se produjo un error al modificar el registro" + ex.Message);
        }
        finally
        {
            sqlConexion.Close();
            sqlConexion.Dispose();
        }

    }

    public async Task EliminarEmpleado(string CodEmpleado)
    {
        SqlConnection sqlConexion = conexion();
        try
        {
            sqlConexion.Open();
            var param = new DynamicParameters();
            param.Add("@CodEmpleado", CodEmpleado, DbType.String, ParameterDirection.Input, 4);
            await sqlConexion.ExecuteScalarAsync("EliminarEmpleado", param, commandType: CommandType.StoredProcedure);
        }
        catch (Exception ex)
        {
            log.LogError("Error : " + ex.ToString());
            throw new Exception("se produjo un error al borrar  empleado" + ex.Message);
        }
        finally
        {
            sqlConexion.Close();
            sqlConexion.Dispose();
        }

    }

}