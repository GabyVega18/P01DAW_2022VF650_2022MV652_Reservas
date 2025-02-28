using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P01_2022VF650_2022MV652.Models;
using Microsoft.EntityFrameworkCore;


namespace P01_2022VF650_2022MV652.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class espaciosController : ControllerBase
    {
        private readonly parqueosDBContext _parqueosDBContexto;

        public espaciosController(parqueosDBContext parqueosDBContext)
        {
            _parqueosDBContexto = parqueosDBContext;

        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<espacios> Listadoespacios = (from e in _parqueosDBContexto.espacios
                                              select e).ToList();
            if (Listadoespacios.Count == 0)
            {
                return NotFound();
            }

            return Ok(Listadoespacios);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult Get(int id)
        {
            espacios? espacios = (from e in _parqueosDBContexto.espacios
                                  where e.Id_espacio == id
                                  select e).FirstOrDefault();
            if (espacios == null)
            {
                return NotFound();
            }

            return Ok(espacios);
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult GuardarEspacios([FromBody] espacios espacios)
        {
            try
            {
                _parqueosDBContexto.espacios.Add(espacios);
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

        public IActionResult ActualizarEspacios(int id, [FromBody] espacios espaciosModificar)
        {
            espacios? espaciosActual = (from e in _parqueosDBContexto.espacios
                                        where e.Id_espacio == id

                                        select e).FirstOrDefault();
            if (espaciosActual == null)
            { return NotFound(); }

            espaciosActual.Id_espacio = espaciosModificar.Id_espacio;
            espaciosActual.sucursalId= espaciosModificar.sucursalId;
            espaciosActual.numero = espaciosModificar.numero;
            espaciosActual.ubicacion= espaciosModificar.ubicacion;
            espaciosActual.costoPorHora = espaciosModificar.costoPorHora;
            espaciosActual.estado = espaciosModificar.estado;

            _parqueosDBContexto.Entry(espaciosActual).State = EntityState.Modified;
            _parqueosDBContexto.SaveChanges();
            return Ok();
        }


        [HttpDelete]
        [Route("Eliminar/{id}")]

        public IActionResult EliminarReserva(int id)
        {
            espacios? espacios = (from e in _parqueosDBContexto.espacios
                                  where e.Id_espacio == id
                                  select e).FirstOrDefault();
            if (espacios == null)
                return NotFound();
            _parqueosDBContexto.espacios.Attach(espacios);
            _parqueosDBContexto.espacios.Remove(espacios);
            _parqueosDBContexto.SaveChanges();
            return Ok(espacios);
        }


    }


}

