using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockFord.Web.Areas.User.Controllers
{
    public class HomeController : UserBaseController
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

       
    }
}
