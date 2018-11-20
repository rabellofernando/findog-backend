using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Vacina")]
    public class Vacina
    {
        [Required]
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Data { get; set; }
        [Required, MaxLength(200)]
        public string Nome_Vacina { get; set; }
        [Required, MaxLength(200)]
        public string Reforco { get; set; }
        


        //coluna da chave estrangeira 
        [Column("CachorroId")]
        public int CachorroId { get; set; }
        [ForeignKey("CachorroId")]
        public virtual Cachorro Cachorro { get; set; }


        


    }
}
