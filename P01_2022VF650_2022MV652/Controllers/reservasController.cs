using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P01_2022VF650_2022MV652.Models;
using Microsoft.EntityFrameworkCore;


namespace P01_2022VF650_2022MV652.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class reservasController : ControllerBase
    {
        private readonly parqueosDBContext _parqueosDBContexto;

        public reservasController(parqueosDBContext parqueosDBContext)
        {
            _parqueosDBContexto = parqueosDBContext;

        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<reservas> Listadoreservas = (from e in _parqueosDBContexto.reservas
                                              select e).ToList();
            if (Listadoreservas.Count == 0)
            {
                return NotFound();
            }

            return Ok(Listadoreservas);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult Get(int id)
        {
            reservas? reservas = (from e in _parqueosDBContexto.reservas
                                 where e.Id_reservas == id
                                 select e).FirstOrDefault();
            if (reservas == null)
            {
                return NotFound();
            }

            return Ok(reservas);
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult GuardarReservas([FromBody] reservas reservas)
        {
            try
            {
                _parqueosDBContexto.reservas.Add(reservas);
                _parqueosDBContexto.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("actualizar/{id}")]

        public IActionResult ActualizarReservas(int id, [FromBody] reservas reservasModificar)
        {
            reservas? reservasActual = (from e in _parqueosDBContexto.reservas
                                       where e.Id_reservas == id

                                       select e).FirstOrDefault();
            if (reservasActual == null)
            { return NotFound(); }

            reservasActual.Id_reservas = reservasModificar.Id_reservas;
            reservasActual.usuarioId = reservasModificar.usuarioId;
            reservasActual.espacioId = reservasModificar.espacioId;
            reservasActual.fecha = reservasModificar.fecha;
            reservasActual.hora = reservasModificar.hora;
            reservasActual.cantidadHoras = reservasModificar.cantidadHoras;

            _parqueosDBContexto.Entry(reservasActual).State = EntityState.Modified;
            _parqueosDBContexto.SaveChanges();
            return Ok();
        }


        [HttpDelete]
        [Route("Eliminar/{id}")]

        public IActionResult EliminarReserva(int id)
        {
            reservas? reservas = (from e in _parqueosDBContexto.reservas
                                 where e.Id_reservas == id
                                 select e).FirstOrDefault();
            if (reservas == null)
                return NotFound();
            _parqueosDBContexto.reservas.Attach(reservas);
            _parqueosDBContexto.reservas.Remove(reservas);
            _parqueosDBContexto.SaveChanges();
            return Ok(reservas);
        }


    }


}

