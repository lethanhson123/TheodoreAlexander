
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System.Globalization;
using System.Threading;

namespace TA.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BaseController : Controller, IActionFilter
    {
        public CultureInfo CultureInfo { get; set; }
        public bool IsActiveTAUS { get; set; }

        public BaseController()
        {
            //CultureInfo = Thread.CurrentThread.CurrentCulture;
            //IsActiveTAUS = false;
            //if (CultureInfo.LCID == 1033)
            //{
            //    IsActiveTAUS = true;
            //}
        }
    }
}
