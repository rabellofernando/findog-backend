using Repository;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server.Controllers.Base
{
    public class BaseController : ApiController
    {
        public UnityOfWork UnityOfWork { get; private set; }
        public BaseController()
        {
            UnityOfWork = new UnityOfWork();
        }

        protected IHttpActionResult IncompleteRequest()
        {
            return InternalServerError("Request Incompleta");
        }

        protected IHttpActionResult InternalServerError(string message)
        {
            return ResponseMessage(HttpStatusCode.InternalServerError, message);
        }

        protected IHttpActionResult ResponseMessage<T>(HttpStatusCode status, T obj)
        {
            return ResponseMessage(Request.CreateResponse(status, obj));
        }

        private IHttpActionResult ResponseMessage(HttpStatusCode status, string message)
        {
            return ResponseMessage(status, new { status = (int)status, message = message });
        }

        protected IHttpActionResult ValidationErros()
        {
            var errors = ModelState.Where(w => w.Value.Errors.Any()).SelectMany(s => s.Value.Errors).Select(s => (s.Exception?.Message ?? s.ErrorMessage)).ToArray();
            return ResponseMessage(HttpStatusCode.BadRequest, new { status = (int)HttpStatusCode.BadRequest, Errors = errors, message = "Campos inválidos" });
        }
    }
}