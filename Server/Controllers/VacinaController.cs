using Server.Controllers.Base;
using System.Linq;
using System.Web.Http;
using Repository;
using Server.Wrappers;
using Server.Identity;
using Server.Extensions;
using Models;

namespace Server.Wrappers
{
    public class VacinaController : BaseController
    {
        [HttpGet]
        [Route("api/vacina")]
        public IHttpActionResult Get()
        {
            return Ok(UnityOfWork.Vacinas.Get());
        }


        [HttpPost]
        [Route("api/vacina")]
        public IHttpActionResult Post([FromBody] CadastrarVacinaRequest VacinaRequest)
        {
        if (VacinaRequest == null) return IncompleteRequest();

        if (!ModelState.IsValid)
            return ValidationErros();

        
        var vacina = VacinaRequest.ToType<Vacina>();

        UnityOfWork.Vacinas.Add(vacina);
        UnityOfWork.Vacinas.SaveChanges();

        return Ok(new { Sucesso = true, Mensagem = "Vacina adicionada com Sucesso" });

        }

        public IHttpActionResult Get(int? Id)
        {
            if (!Id.HasValue)
                return BadRequest("Id não pode ser null ;)");

            //var coordenada = UnityOfWork.Coordenada.Get().Where(m=>m.CachorroId == Id.Value).ToList().Max(u=>u.Id);
            //var teste = Calc.Convertdd(coordenadas.FirstOrDefault());

            var Vacina = UnityOfWork.Vacinas.FindListBy(m => m.CachorroId == Id ).ToList();
            if (Vacina.Count() == 0)
                return Ok("Não Há Vacinas para este Cachorro");

            return Ok(new { Vacinas = Vacina });
        }


    }

}