using System.Web.Http;

namespace TextLand.Controllers
{
    public class StatusController : ApiController
    {
        public string Get()
        {
            return "ok!";
        }
    }
}
