using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{

    [Table("Dispositivo")]
    public class Dispositivo
    {
        [Required]
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Nome { get; set; }
        [Required]
        public int NumeroSerie { get; set; }
        [Required]
        public int Status { get; set; }




    }
}
