using Bnpp.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bnpp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportApiController : ControllerBase
    {
        private IDamageabilityService _reportService;

        public ReportApiController(IDamageabilityService reportService)
        {
            _reportService = reportService;
        }


        [HttpGet]
        public IActionResult GetReports()
        {
            var reportofsaccor = _reportService.GetAllReportsSortByReportDate();

            if (reportofsaccor.Count == 0)
            {
                return NotFound();
            }

            return Ok(reportofsaccor);
        }
    }
}
