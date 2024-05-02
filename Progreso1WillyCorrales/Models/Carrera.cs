using System.ComponentModel.DataAnnotations;

namespace Progreso1WillyCorrales.Models
{
    public class Carrera
    {
        [Key]
        public int IdCarrera { get; set; }
        [Required]
        public string nombre_carrera { get; set; }
        public int numero_semestres { get; set; }
    }
}
