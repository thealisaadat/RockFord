using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockFord.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        
        public IActionResult Index()
        {
            ViewData[InfoMessage] = "خوش آمدید";
            return View();
        }
    }
}
