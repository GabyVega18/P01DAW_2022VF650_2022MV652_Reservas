using System.ComponentModel.DataAnnotations;

namespace P01_2022VF650_2022MV652.Models
{
    public class reservas
    {
        [Key]
        public int Id_reservas { get; set; }
        public int usuarioId { get; set; }
        public int espacioId { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public int cantidadHoras { get; set; }
    }
}