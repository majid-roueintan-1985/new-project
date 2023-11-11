using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace Bnpp.Web.Controllers
{
    [Authorize]
    public class ElectricalController : Controller
    {


        [Microsoft.AspNetCore.Mvc.Route("Electrical")]
        public IActionResult Index()
        {
            return View();
        }


    }
}
