using Server.Controllers.Base;
using System.Linq;
using System.Web.Http;
using Repository;
using Server.Wrappers;
using Server.Identity;
using Server.Extensions;
using Models;
using Server.Helper;
using Server.Services;
using System;

namespace Server.Controllers
{
    public class CoordenadaController : BaseController
    {
        [HttpGet]
        [Route("api/coordenada")]
        public IHttpActionResult Get()
        {
            //return Ok("zico tio");
            return Ok(UnityOfWork.Coordenada.Get());
        }


        [HttpPost]
        [Route("api/coordenada")]
        public IHttpActionResult Post([FromBody] CadastrarCoordenadaRequest Coordenadarequest)
        {
            
            if (Coordenadarequest == null)
                return IncompleteRequest();

            if (!ModelState.IsValid)
                return ValidationErros();

            var coord = Coordenadarequest.ToType<Coordenada>();
            //coord = Calc.Convertdd(coord);

            var CoordRecebimento = UnityOfWork.Cachorro.Get().Where(m => m.DispositivoId == coord.DispositivoId).FirstOrDefault();
            var usuario = UnityOfWork.Usuario.Get().Where(m => m.Id == CoordRecebimento.UsuarioId).FirstOrDefault();

            //coord.Latitude.Replace(".", "");
            //coord.Longetitude.Replace(".", "");
            UnityOfWork.Coordenada.Add(coord);
            UnityOfWork.Coordenada.SaveChanges();

            double teste = Calc.Calcular(double.Parse(CoordRecebimento.Lat), double.Parse(CoordRecebimento.Lng), double.Parse(coord.Latitude), double.Parse(coord.Longitude));
            //double teste = Calc.Calcular(Convert.ToDouble(CoordRecebimento.Lat), Convert.ToDouble(CoordRecebimento.Lng), Convert.ToDouble(coord.Latitude), Convert.ToDouble(coord.Longetitude));
            

            if (teste > CoordRecebimento.Raio && CoordRecebimento.Emergencia == true)
            {
                NotificacaoService.EnviarNotificacao(usuario.Id.ToString(), CoordRecebimento.Nome);
                return Ok(11);
            }

            else if (CoordRecebimento.Emergencia == true && teste < CoordRecebimento.Raio)
            {
                return Ok(1);
            }

            else if (CoordRecebimento.Emergencia == false && teste > CoordRecebimento.Raio)
            {
                NotificacaoService.EnviarNotificacao(usuario.Id.ToString(), CoordRecebimento.Nome);
                return Ok(00);
            }
           else 
            {
                return Ok(0);
            }         
            


        }

        

       
        public IHttpActionResult Get(int? Id)
        {

            if (!Id.HasValue)
                return BadRequest("Id não pode ser null ;)");

            var verificao = UnityOfWork.Coordenada.Get().Where(m => m.DispositivoId == Id.Value).ToList();
            if (verificao.Count() != 0)
            {
                return base.Ok(UnityOfWork.Coordenada.FindListBy(m => m.DispositivoId == Id.Value).ToList().Last());
                //return base.Ok(UnityOfWork.Coordenada.FindListBy(m => m.DispositivoId == Id.Value).ToList());
            }
            else
                return Ok("Não Há Coordenadas para este Cachorro");
            //var coordenadas = UnityOfWork.Coordenada.Get().Where(m=>m.CachorroId == Id.Value).ToList();
            //var teste = Calc.Convertdd(coordenadas.FirstOrDefault());


            //var Coordenada = UnityOfWork.Coordenada.Get().Where(m => m.CachorroId == Id.Value).ToList().Last();
            //var coordenadas = UnityOfWork.Coordenada.FindListBy(m => m.CachorroId == Id).ToList();
            //if (coordenadas.Count() == 0)
            //    return NotFound();
            //var Coordenada1 = UnityOfWork.Coordenada.FindListBy(m => m.CachorroId == Id.Value).ToList().Last();
           
               // return Ok("Nenhuma Coordenada");
            
            //return Ok(verificao);
        }

        




    }
}
