using System.ComponentModel.DataAnnotations;

namespace P01_2022VF650_2022MV652.Models
{
    public class usuarios
    {
        [Key]
        public int Id_usuario { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public string contraseña { get; set; }
        public string rol { get; set; }

    }
}