using System.ComponentModel.DataAnnotations;

namespace Server.Wrappers
{
    public abstract class UsuarioRequest
    {
        [Required, MaxLength(200)]
        public string Nome { get; set; }
        [Required, MaxLength(15)]
        public string Cpf { get; set; }
        [Required, MaxLength(200)]
        public string Email { get; set; }
        [Required, MaxLength(14)]
        public string Celular { get; set; }
        
    }

    public class CadastrarUsuarioRequest : UsuarioRequest
    {
        public string Senha { get; set; }
    }

    public class AtualizarUsuarioRequest : UsuarioRequest
    {
        [Required]
        public int Id { get; set; }
    }

    public class ConfirmaLoginRequest
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}