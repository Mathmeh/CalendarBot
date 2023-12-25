using CalendarBot.Oauth;
using Microsoft.AspNetCore.Mvc;

namespace CalendarBot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OauthController : Controller
    {
        [HttpGet]
        public void Oauth()
        {
            OauthClass.GetAcces();
        }
    }
}
