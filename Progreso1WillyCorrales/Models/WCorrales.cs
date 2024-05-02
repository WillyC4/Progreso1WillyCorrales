using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Progreso1WillyCorrales.Models
{
    public class WCorrales
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
        [MaxLength(250)]
        public double decima { get; set; }
        public Boolean SiNo { get; set; }
        public DateTime fecha { get; set; }

        [ForeignKey("IdCarrera")]
        public int? carreraID { get; set; }
        public Carrera? Carreras { get; set; }
    }
}
