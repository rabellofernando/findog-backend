using Server.Controllers.Base;
using System.Linq;
using System.Web.Http;
using Repository;

namespace Server.Controllers
{
    public class DefaultController : BaseController
    {
        public IHttpActionResult Get()
        {
            return Ok("Rodandoooooooooooo ;)");
        }       
    }
}