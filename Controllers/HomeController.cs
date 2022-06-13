using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RockFord.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using RockFord.Application.Services.Interfaces;
using RockFord.DataLayer.DTOs.Content;
using RockFord.Web.Controllers;

namespace RockFord.Web.Controllers
{
    public class HomeController : BaseController
    {
        #region Constractor

        private readonly IContentService _contentService;

        public HomeController(IContentService contentService)
        {
            _contentService = contentService;
        }

        #endregion

        public IActionResult Index()
        {
            ViewData[SuccessMessage] = "خوش آمدید";
            return View();
        }

        #region SinglePage

        [HttpGet("SinglePage/{articleId}")]
        public async Task<IActionResult> SinglePage(long articleId)
        {
           
            var article = await _contentService.GetArticleById(articleId);
            if (article == null) return NotFound();
            return View(article);
        }
     

        #endregion

    }
}
