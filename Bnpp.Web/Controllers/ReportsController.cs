using Microsoft.AspNetCore.Mvc;

namespace Bnpp.Web.Controllers
{
    public class ReportsController : Controller
    {

        [Microsoft.AspNetCore.Mvc.Route("Reports")]
        public IActionResult Index()
        {
            return View();
        }

        [Microsoft.AspNetCore.Mvc.Route("MechanicalReport")]
        public IActionResult MechanicalReport()
        {
            return View();
        }

        [Microsoft.AspNetCore.Mvc.Route("ElectricalReport")]
        public IActionResult ElectricalReport()
        {
            return View();
        }

        [Microsoft.AspNetCore.Mvc.Route("I & C Equipments")]
        public IActionResult ICEquipments()
        {
            return View();
        }

        [Microsoft.AspNetCore.Mvc.Route("StructuresReport")]
        public IActionResult StructuresReport()
        {
            return View();
        }
    }
}
