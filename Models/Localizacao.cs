using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Localizacao")]
    public class Localizacao
    {
        [Required]
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Latitude { get; set; }
        [Required, MaxLength(15)]
        public string Longitude { get; set; }

        //coluna da chave estrangeira 
        [Column("CachorroId")]
        public int CachorroId { get; set; }

        //objeto user
        [ForeignKey("CachorroId")]
        public virtual Cachorro Cachorro { get; set; }
        //ForeignKeyAttribute Cachorros_ID
    }
}
