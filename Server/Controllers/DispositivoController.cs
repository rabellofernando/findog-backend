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
    public class DispositivoController : BaseController
    {
        [HttpGet]
        [Route("api/dispositivo")]
        public IHttpActionResult Get()
        {
            //return Ok("zico tio");
            return Ok(UnityOfWork.Dispositivos.Get());
        }


        [HttpPost]
        [Route("api/dispositivo")]
        public IHttpActionResult Post([FromBody] CadastrarDispositivoRequest DispositivoRequest)
        {
            if (DispositivoRequest == null)
                return IncompleteRequest();

            if (!ModelState.IsValid)
            {
                return Ok(new { Sucesso = false, Mensagem = (ValidationErros()) });
            }

            var dispositivo = DispositivoRequest.ToType<Dispositivo>();

            UnityOfWork.Dispositivos.Add(dispositivo);
            UnityOfWork.Dispositivos.SaveChanges();

            return Ok(new { Sucesso = true, Mensagem = "Dispositivo Adicionado com Sucesso" });
        }

        //public IHttpActionResult Get(int? Id)
        //{
        //    if (!Id.HasValue)
        //        return BadRequest("Id não pode ser null ;)");

        //    //var coordenada = UnityOfWork.Coordenada.Get().Where(m=>m.CachorroId == Id.Value).ToList().Max(u=>u.Id);
        //    //var teste = Calc.Convertdd(coordenadas.FirstOrDefault());

        //    var cachorro = UnityOfWork.Cachorro.FindListBy(m => m.UsuarioId == Id).ToList();
        //    if (cachorro.Count() == 0)
        //        return NotFound();

        //    return Ok(new { Cachorros = cachorro });
        //}


    }
}
