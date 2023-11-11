using Bnpp.Core.Services;
using Bnpp.Core.Services.Interfaces;
using Bnpp.DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bnpp.Web.Controllers
{
	public class SettingsController : Controller
	{
		private IUnitsService _units;
		private IConfiguration Configuration;
		public SettingsController(IUnitsService units, IConfiguration _configuration)
		{
			Configuration = _configuration;
			_units = units;
		}


		[Route("Settings")]
		public IActionResult Index()
		{
			return View();
		}


		#region  UNIT


		[Route("Units")]
		public IActionResult Units()
		{
			//var groups = _units.GetUnitGroupForManageCourse();
			//ViewBag.Groups = new SelectList(groups, "Value", "Text");

			//var subGrous = _units.GetUnitSubGroupForManageCourse(int.Parse(groups.First().Value));
			//ViewBag.SubGroups = new SelectList(subGrous, "Value", "Text");

            ViewBag.Groups = _units.GetListOfGroups();

            return View(_units.GetAllGroups());
		}

		public IActionResult Create(int? id)
		{
			Units grops = new Units();
			grops.ParentId = id;

			return View(grops);
		}

		[HttpPost]
		public IActionResult Create(Units groups)
		{

          
            if (_units.IsExistParameter(groups.UnitTitle))
            {
                Response.StatusCode = 500;
                return Json("The entered Parameter is Already Exist!");
            }
  
            if (groups.UnitTitle != null)
			{
                _units.AddNewUnit(groups);
			}
			
			return Json(" Electormotors Successfully Deleted.");
		}

		public IActionResult GetSubGroups(int id)
		{
			List<SelectListItem> list = new List<SelectListItem>()
			{
				//new SelectListItem(){Text = "Select",Value = ""}
			};
			list.AddRange(_units.GetUnitSubGroupForManageCourse(id));
			return Json(new SelectList(list, "Value", "Text"));
		}

		public IActionResult DeleteGroup(string[] groupId)
		{

			foreach (string id in groupId)
			{
				_units.DeleteUnitGroup(Convert.ToInt32(id));
			}

			return Json("TransientGroups Successfully Deleted.");
		}

		#endregion

		[Route("UnitConvertor")]
		public IActionResult UnitConvertor()
		{
			return View();
		}

		//
		public IActionResult LengthConverter()
		{
			return View();
		}

		public IActionResult TemperatureConverter()
		{
			return View();
		}

		public IActionResult WeightConverter()
		{
			return View();
		}

		public IActionResult SpeedConverter()
		{
			return View();
		}
	}
}
