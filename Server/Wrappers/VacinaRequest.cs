using System.ComponentModel.DataAnnotations;

namespace Server.Wrappers
{
    public abstract class VacinaRequest
    {
        
        [Required]
        public string Nome_Vacina { get; set; }
        [Required, MaxLength(14)]
        public string Reforco { get; set; }
        [Required, MaxLength(200)]
        public string Data { get; set; }

    }

    public class CadastrarVacinaRequest : VacinaRequest
    {
       
        [Required]
        public int CachorroId { get; set; }
    }

}