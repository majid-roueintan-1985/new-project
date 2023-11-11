using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Bnpp.Web.Controllers
{
    [Authorize]
    public class DataEntryController : Controller
    {
        [Route("DataEntry")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
