using System.ComponentModel.DataAnnotations;

namespace Server.Wrappers
{
   
    
        public abstract class CoordenadaRequest
        {
        [Required]
        public int DispositivoId { get; set; }
        [MaxLength(200)]
        public string Coord { get; set; }
        }

        public class CadastrarCoordenadaRequest : CoordenadaRequest
        {

        [MaxLength(200)]
        public string Latitude { get; set; }
        [MaxLength(200)]
        public string Longitude { get; set; }
        }
}

