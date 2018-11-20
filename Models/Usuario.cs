using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Usuario")]
    public class Usuario 
    {
        [Required]
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Nome { get; set; }
        [Required, MaxLength(15)]
        public string Cpf { get; set; }
        [Required, MaxLength(200)]
        public string Email { get; set; }
        [Required, MaxLength(14)]
        public string Celular { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        public string Senha { get; set; }
        
    
    }
}
