using System.ComponentModel.DataAnnotations;

namespace Server.Wrappers
{
    public abstract class DispositivoRequest
    {

        [Required]
        public int Id { get; set; }


    }

    public class CadastrarDispositivoRequest
    {
        
        [Required, MaxLength(200)]
        public string Nome { get; set; }
        [Required]
        public int NumeroSerie { get; set; }
    }

}