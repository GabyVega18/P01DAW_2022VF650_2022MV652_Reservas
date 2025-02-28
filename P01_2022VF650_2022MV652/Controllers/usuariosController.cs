using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P01_2022VF650_2022MV652.Models;
using Microsoft.EntityFrameworkCore;


namespace P01_2022VF650_2022MV652.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usuariosController : ControllerBase
    {
        private readonly parqueosDBContext _parqueosDBContexto;

        public usuariosController(parqueosDBContext parqueosDBContext)
        {
            _parqueosDBContexto = parqueosDBContext;

        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<usuarios> Listadousuarios = (from e in _parqueosDBContexto.usuarios
                                                        select e).ToList();
            if (Listadousuarios.Count == 0)
            {
                return NotFound();
            }

            return Ok(Listadousuarios);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult Get(int id)
        {
            usuarios? usuario = (from e in _parqueosDBContexto.usuarios
                                            where e.Id_usuario == id
                                            select e).FirstOrDefault();
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult GuardarUsuarios([FromBody] usuarios usuario)
        {
            try
            {
                _parqueosDBContexto.usuarios.Add(usuario);
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

        public IActionResult ActualizarUsuarios(int id, [FromBody] usuarios usuariosModificar)
        {
            usuarios? usuarioActual = (from e in _parqueosDBContexto.usuarios
                                                  where e.Id_usuario == id

                                                  select e).FirstOrDefault();
            if (usuarioActual == null)
            { return NotFound(); }

            usuarioActual.Id_usuario = usuariosModificar.Id_usuario;
            usuarioActual.nombre = usuariosModificar.nombre;
            usuarioActual.correo = usuariosModificar.correo;
            usuarioActual.telefono = usuariosModificar.telefono;
            usuarioActual.contraseña = usuariosModificar.contraseña;
            usuarioActual.rol = usuariosModificar.rol;

            _parqueosDBContexto.Entry(usuarioActual).State = EntityState.Modified;
            _parqueosDBContexto.SaveChanges();
            return Ok();
        }


        [HttpDelete]
        [Route("Eliminar/{id}")]

        public IActionResult EliminarUsuario(int id)
        {
            usuarios? usuario = (from e in _parqueosDBContexto.usuarios
                                            where e.Id_usuario == id
                                            select e).FirstOrDefault();
            if (usuario == null)
                return NotFound();
            _parqueosDBContexto.usuarios.Attach(usuario);
            _parqueosDBContexto.usuarios.Remove(usuario);
            _parqueosDBContexto.SaveChanges();
            return Ok(usuario);
        }


    }


}
