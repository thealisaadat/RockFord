using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using RockFord.Application.Services.Interfaces;

namespace RockFord.Web.Areas.Admin.ViewComponents
{
    public class MainGroupViewComponent : ViewComponent
    {
        #region MainList

        private readonly IContentService _service;

        public MainGroupViewComponent(IContentService service)
        {
            _service = service;
        }
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var gr = await _service.GetAllMainGroup();
            ViewData["MainGroups"] = new SelectList(gr,"Value","Text");
            return View("MainGroup");
        }

        #endregion
    }
}
