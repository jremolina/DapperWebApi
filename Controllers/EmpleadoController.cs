using System.Reflection.Metadata.Ecma335;
using DapperWebApi.DTO;
using DapperWebApi.Modelos;
using DapperWebApi.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IServicioEmpleadosql _servicioEmpleado;
        public EmpleadoController(IServicioEmpleadosql servicioEmpleado)
        {
            _servicioEmpleado = servicioEmpleado;
        }

        [HttpGet]
        public IEnumerable<EmpleadoDTO> GetEmpleados()
        {
            // return _servicioEmpleado.GetEmpleados();
            return _servicioEmpleado.ListarEmpleados().Select(e => e.convertirADTO());
        }

        [HttpGet("{CodEmpleado}")]
        public ActionResult<EmpleadoDTO> GetEmpleado(string CodEmpleado)
        {
            var empleado = _servicioEmpleado.ObtenerEmpleado(CodEmpleado).convertirADTO();
            if (empleado is null)
            {
                return NotFound();
            }
            return empleado;
        }

        [HttpPost]
        public ActionResult<EmpleadoDTO> PostEmpleado(EmpleadoDTO e)
        {
            Empleado empleado = new Empleado
            {
                // no es necesario cuando se trabaja con bd ya que se definio tipo de campo autoinc
                // Id = _servicioEmpleado.GetEmpleados().Max(x => x.Id) + 1, 
                Nombre = e.Nombre,
                CodEmpleado = e.CodEmpleado,                
                Email = e.Email,
                Edad = e.Edad,
                fechaIngreso = DateTime.Now
            };

            _servicioEmpleado.CrearEmpleado(empleado);
            return empleado.convertirADTO();
        }

        [HttpPut]
        public ActionResult<EmpleadoDTO> PutEmpleado(EmpleadoDTO e)
        {
            var empleadoaux = _servicioEmpleado.ObtenerEmpleado(e.CodEmpleado);
            if (empleadoaux is null)
            {
                return NotFound();
            }
            empleadoaux.Nombre = e.Nombre;
            empleadoaux.CodEmpleado = e.CodEmpleado;            
            empleadoaux.Email = e.Email;
            empleadoaux.Edad = e.Edad;

            _servicioEmpleado.ActualizarEmpleado(empleadoaux);
            return e;
        }

        [HttpDelete]
        public ActionResult DeleteEmpleado(string CodEmpleado)
        {
            var empleado = _servicioEmpleado.ObtenerEmpleado(CodEmpleado);
            if (empleado is null)
            {
                return NotFound();
            }
            _servicioEmpleado.EliminarEmpleado(CodEmpleado);
            return Ok();

        }
    }
}
