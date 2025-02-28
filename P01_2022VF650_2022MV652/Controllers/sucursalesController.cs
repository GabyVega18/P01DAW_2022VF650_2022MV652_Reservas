using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P01_2022VF650_2022MV652.Models;
using Microsoft.EntityFrameworkCore;

namespace P01_2022VF650_2022MV652.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class sucursalesController : ControllerBase
    {
        private readonly parqueosDBContext _parqueosDBContexto;

        public sucursalesController(parqueosDBContext parqueosDBContext)
        {
            _parqueosDBContexto = parqueosDBContext;

        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<sucursales> Listadosucursal = (from e in _parqueosDBContexto.sucursales
                                              select e).ToList();
            if (Listadosucursal.Count == 0)
            {
                return NotFound();
            }

            return Ok(Listadosucursal);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult Get(int id)
        {
            sucursales? sucursal = (from e in _parqueosDBContexto.sucursales
                                 where e.Id_sucursal == id
                                 select e).FirstOrDefault();
            if (sucursal == null)
            {
                return NotFound();
            }

            return Ok(sucursal);
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult GuardarSucursal([FromBody] sucursales sucursal)
        {
            try
            {
                _parqueosDBContexto.sucursales.Add(sucursal);
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

        public IActionResult ActualizarSucursales(int id, [FromBody] sucursales sucursalModificar)
        {
            sucursales? socursalActual = (from e in _parqueosDBContexto.sucursales
                                       where e.Id_sucursal == id
                                       select e).FirstOrDefault();
            if (socursalActual == null)
            { return NotFound(); }

            socursalActual.Id_sucursal = sucursalModificar.Id_sucursal;
            socursalActual.nombre = sucursalModificar.nombre;
            socursalActual.direccion = sucursalModificar.direccion;
            socursalActual.telefono = sucursalModificar.telefono;
            socursalActual.administradorId = sucursalModificar.administradorId;
            socursalActual.numeroEspacios = sucursalModificar.numeroEspacios;

            _parqueosDBContexto.Entry(socursalActual).State = EntityState.Modified;
            _parqueosDBContexto.SaveChanges();
            return Ok();
        }


        [HttpDelete]
        [Route("Eliminar/{id}")]

        public IActionResult EliminarSucursal(int id)
        {
            sucursales? sucursal = (from e in _parqueosDBContexto.sucursales
                                 where e.Id_sucursal == id
                                 select e).FirstOrDefault();
            if (sucursal == null)
                return NotFound();
            _parqueosDBContexto.sucursales.Attach(sucursal);
            _parqueosDBContexto.sucursales.Remove(sucursal);
            _parqueosDBContexto.SaveChanges();
            return Ok(sucursal);
        }
    }
}
