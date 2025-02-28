using System.ComponentModel.DataAnnotations;

namespace P01_2022VF650_2022MV652.Models
{
    public class espacios
    {
        [Key]
        public int Id_espacio { get; set; }
        public int sucursalId { get; set; }
        public int numero { get; set; }
        public string ubicacion { get; set; }
        public decimal costoPorHora { get; set; }
        public string estado { get; set; }
    }
}