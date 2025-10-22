using DapperWebApi.DTO;
using DapperWebApi.Modelos;
using DapperWebApi.Servicios;
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
        public async Task<IEnumerable<EmpleadoDTO?>> GetEmpleados()
        {
            // return _servicioEmpleado.GetEmpleados();
            var ListaEmpleados = (await _servicioEmpleado.ListarEmpleados()).Select(e => e.convertirADTO());
            return ListaEmpleados;

        }

        [HttpGet("{CodEmpleado}")]
        public async Task<ActionResult<EmpleadoDTO>> GetEmpleado(string CodEmpleado)
        {
            var empleado = (await _servicioEmpleado.ObtenerEmpleado(CodEmpleado)).convertirADTO();
            if (empleado is null)
            {
                return NotFound();
            }
            return empleado;
        }

        [HttpPost]
        public async Task<ActionResult<EmpleadoDTO>> PostEmpleado(EmpleadoDTO e)
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

            await _servicioEmpleado.CrearEmpleado(empleado);

            return empleado.convertirADTO();
        }

        [HttpPut]
        public async Task<ActionResult<EmpleadoDTO>> PutEmpleado(EmpleadoDTO e)
        {
            var empleadoaux = await _servicioEmpleado.ObtenerEmpleado(e.CodEmpleado);
            if (empleadoaux is null)
            {
                return NotFound();
            }
            empleadoaux.Nombre = e.Nombre;
            empleadoaux.CodEmpleado = e.CodEmpleado;
            empleadoaux.Email = e.Email;
            empleadoaux.Edad = e.Edad;

            await _servicioEmpleado.ActualizarEmpleado(empleadoaux);
            return e;
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteEmpleado(string CodEmpleado)
        {
            var empleado = await _servicioEmpleado.ObtenerEmpleado(CodEmpleado);
            if (empleado is null)
            {
                return NotFound();
            }
            await _servicioEmpleado.EliminarEmpleado(CodEmpleado);
            return Ok();

        }
    }
}
