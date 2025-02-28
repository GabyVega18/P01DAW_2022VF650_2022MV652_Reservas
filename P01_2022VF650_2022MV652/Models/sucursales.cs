using System.ComponentModel.DataAnnotations;

namespace P01_2022VF650_2022MV652.Models
{
    public class sucursales
    {
        [Key]
        public int Id_sucursal { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string  telefono { get; set; }
        public int administradorId { get; set; }
        public int numeroEspacios { get; set; }


    }
}
