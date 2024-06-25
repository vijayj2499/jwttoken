using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace JWTtoken.Controllers
{
    [System.Web.Http.RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("login")]
        public System.Web.Http.IHttpActionResult Login(LoginModel model)
        {
            if (model.Username == "test" && model.Password == "password")
            {
                var token = TokenGenerator.GenerateToken(model.Username);
                return Ok(new { token });
            }
            return Unauthorized();
        }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
