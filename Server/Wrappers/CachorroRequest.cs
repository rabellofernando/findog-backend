using System.ComponentModel.DataAnnotations;

namespace Server.Wrappers
{
    public abstract class CachorroRequest
    {
        
        [Required]
        public int UsuarioId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required, MaxLength(14)]
        public string Dt_nasc { get; set; }
        [Required, MaxLength(200)]
        public string Raca { get; set; }
        [Required]
        public int DispositivoId { get; set; }


    }

    public class CadastrarCachorroRequest : CachorroRequest
    {
        
        [Required]
        public string Endereco { get; set; }
        [Required]
        public int Raio { get; set; }
        [Required]
        public bool Emergencia { get; set; }
        public string Lat { get; set; }
        
        public string Lng { get; set; }
    }
            
      

    public class InativoCachorroRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int Status { get; set; }
    }
}