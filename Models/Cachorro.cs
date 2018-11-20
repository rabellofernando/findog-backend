using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Cachorro")]
    public class Cachorro
    {
        [Required]
        public int Id { get; set; }

        //teste


        [Required, MaxLength(200)]
        public string Nome { get; set; }

        //coluna da chave estrangeira 
        [Column("UsuarioId")]
        public int UsuarioId { get; set; }

        //objeto user
        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }

        //coluna da chave estrangeira 
        [Column("DispositivoId")]
        public int DispositivoId { get; set; }

        //objeto user
        [ForeignKey("DispositivoId")]
        public virtual Dispositivo Dispositivo { get; set; }


        [Required]
        public int Status { get; set; }

        [Required, MaxLength(14)]
        public string Dt_nasc { get; set; }
        [Required, MaxLength(200)]
        public string Raca { get; set; }
        
        [Required]
        public int Raio { get; set; }

        [Required]
        public string Endereco { get; set; }
        [Required]
        public string Lat { get; set; }
        [Required]
        public string  Lng { get; set; }

        [Required]
        public bool Emergencia { get; set; }
        
        
    }
}
