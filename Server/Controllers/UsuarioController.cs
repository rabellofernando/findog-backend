using Server.Controllers.Base;
using System.Linq;
using System.Web.Http;
using Repository;
using Server.Wrappers;
using Server.Identity;
using Server.Extensions;
using Models;

namespace Server.Controllers
{
    public class UsuarioController : BaseController
    {
        public IHttpActionResult Get()
        {
            return Ok(UnityOfWork.Usuario.Get());
        }

        public IHttpActionResult Get(int? id)
        {
            if (!id.HasValue)
                return BadRequest("Id não pode ser null ;)");

            var usuario = UnityOfWork.Usuario.Get(id.Value);
            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        public IHttpActionResult Put([FromBody] AtualizarUsuarioRequest usuarioRequest)
        {
            if (usuarioRequest == null) return IncompleteRequest();

            if (!ModelState.IsValid)
                return ValidationErros();

            var usuario = UnityOfWork.Usuario.FindBy(s => s.Id == usuarioRequest.Id);
            if (usuario == null)
                return NotFound();

            usuario = usuarioRequest.ToType(usuario);

            UnityOfWork.Usuario.Update(usuario);
            UnityOfWork.Usuario.SaveChanges();

            return Ok("Usuario atualizado com sucesso");
        }

        public IHttpActionResult Post([FromBody] CadastrarUsuarioRequest usuarioRequest)
        {
            if (usuarioRequest == null) return IncompleteRequest();

            if (!ModelState.IsValid)
                return ValidationErros();

            var validate = Validate(usuarioRequest.Email, usuarioRequest.Cpf);
            if (!validate.Success)
                return Ok( new { Sucesso = false, Mensagem = (validate.Message) });

            var usuario = usuarioRequest.ToType<Usuario>();

            UnityOfWork.Usuario.Add(usuario);
            UnityOfWork.Usuario.SaveChanges();

            return Ok(new { Sucesso = true, Mensagem = "Só logar agora (:" });

        }

        [HttpPost]
        [Route("api/usuario/login")]
        public IHttpActionResult Login([FromBody] ConfirmaLoginRequest usuarioRequest)
        {
            if (usuarioRequest == null) return IncompleteRequest();

            if (!ModelState.IsValid)
                return ValidationErros();

            var usuario = UnityOfWork.Usuario.FindBy(w => w.Email == usuarioRequest.Email && w.Senha == usuarioRequest.Senha);

            if (usuario != null)
            {
                return Ok(new { Sucesso = true, Mensagem = "Ok" , Id = usuario.Id});

            }

            return Ok(new { Sucesso = false, Mensagem = "Credenciais Invalidas"});


        }

        private UserValidate Validate(string email, string cpf)
        {
            var userValidate = new UserValidate { Success = false };

            var emailExists = UnityOfWork.Usuario.FindBy(w => w.Email == email)?.Email != null;
            if (emailExists)
            {
                userValidate.Message = "E-mail já Existente";
                return userValidate;
            }

            var cpfExists = UnityOfWork.Usuario.FindBy(w => w.Cpf == cpf) != null;
            if (cpfExists)
            {
                userValidate.Message = "CPF já existente";
                return userValidate;
            }

            userValidate.Success = true;
            return userValidate;
        }

    }
}