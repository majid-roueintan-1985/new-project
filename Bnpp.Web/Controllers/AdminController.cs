using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Bnpp.Core.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace Bnpp.Web.Controllers
{
    public class AdminController : Controller
    {
		private IBasicDataService _dataService;
		public AdminController(IBasicDataService dataService)
		{
			
			_dataService = dataService;
		}


		[Authorize]
        [Route("Admin")]
        public IActionResult Index()
        {
            return View();
        }
		public IActionResult gallery()
		{
            return View(_dataService.GetAllGeneralDataDocument(45));
        }
    }
}
