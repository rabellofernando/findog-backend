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
    public class CachorroController : BaseController
    {
        [HttpGet]
        [Route("api/cachorro")]
        public IHttpActionResult Get()
        {
            //return Ok("zico tio");
            return Ok(UnityOfWork.Cachorro.Get());
        }


        [HttpPost]
        [Route("api/cachorro")]
        public IHttpActionResult Post([FromBody] CadastrarCachorroRequest cachorroRequest)
        {
            if (cachorroRequest == null)
                return IncompleteRequest();

            if (!ModelState.IsValid)
            {
                return Ok(new { Sucesso = false, Mensagem = (ValidationErros()) });
            }

            var cachorro = cachorroRequest.ToType<Cachorro>();     
            
            UnityOfWork.Cachorro.Add(cachorro);
            UnityOfWork.Cachorro.SaveChanges();

            return Ok(new { Sucesso = true, Mensagem = "Cachorro Adicionado com Sucesso" });
        }

        public IHttpActionResult Get(int? Id)
        {
            if (!Id.HasValue)
                return BadRequest("Id não pode ser null ;)");

            //var coordenada = UnityOfWork.Coordenada.Get().Where(m=>m.CachorroId == Id.Value).ToList().Max(u=>u.Id);
            //var teste = Calc.Convertdd(coordenadas.FirstOrDefault());

            //var cachorro = UnityOfWork.Cachorro.Get().Where(m=>m.Status !=0 ).ToList()


            var cachorro = UnityOfWork.Cachorro.FindListBy(m => m.UsuarioId == Id && m.Status == 0 ).ToList();
            if (cachorro.Count() == 0)
                return NotFound();

            return Ok(new { Cachorros = cachorro });
        }

        [HttpPut]
        [Route("api/cachorro")]
        public IHttpActionResult Put([FromBody] InativoCachorroRequest Cachorro)
        {
            if (Cachorro == null) return IncompleteRequest();

            if (!ModelState.IsValid)
                return ValidationErros();

            var cachorro = UnityOfWork.Cachorro.FindBy(s => s.Id == Cachorro.Id);
            if (cachorro == null)
                return NotFound();

            cachorro = Cachorro.ToType(cachorro);

            UnityOfWork.Cachorro.Update(cachorro);
            UnityOfWork.Cachorro.SaveChanges();

            return Ok(new { Sucesso = true, Mensagem = "Cachorro Apagado com Sucesso" });
        }

    }
}
