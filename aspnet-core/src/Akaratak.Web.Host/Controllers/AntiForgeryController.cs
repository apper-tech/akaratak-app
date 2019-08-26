using Microsoft.AspNetCore.Antiforgery;
using Akaratak.Controllers;

namespace Akaratak.Web.Host.Controllers
{
    public class AntiForgeryController : AkaratakControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
