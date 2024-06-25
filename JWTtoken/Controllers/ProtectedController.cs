using System.Web.Http;

namespace JWTtoken.Controllers
{
    
    [RoutePrefix("api/protected")]
    public class ProtectedController : ApiController
    {
        [HttpGet]
        [Route("data")]
        [Authorize]
        public IHttpActionResult GetProtectedData()
        {
            return Ok("This is protected data");
        }

        [HttpGet]
        [Route("datanojwt")]
        public IHttpActionResult GetProtectedDatanonjwt()
        {
            return Ok("This is un protected data");
        }
    }
}
