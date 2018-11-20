using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Coordenada")]
    public class Coordenada
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(200)]
        public string Coord { get; set; }
        [MaxLength(200)]
        public string Raio { get; set; }


        ////coluna da chave estrangeira 
        //[Column("CachorroId", Order = 2)]
        //public int CachorroId { get; set; }

        ////objeto user
        //[ForeignKey("CachorroId")]
        //public virtual Cachorro Cachorro { get; set; }
        ////ForeignKeyAttribute Cachorros_ID

        //coluna da chave estrangeira 
        [Column("DispositivoId")]
        public int DispositivoId { get; set; }

        //objeto user
        [ForeignKey("DispositivoId")]
        public virtual Dispositivo Dispositivo { get; set; }

        public string Longitude { get; set; }
        public string Latitude { get; set; }



    }
}
