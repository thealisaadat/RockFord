using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RockFord.Application.Services.Interfaces;
using RockFord.DataLayer.DTOs.Content;

namespace RockFord.Web.Areas.Admin.Controllers
{
    public class ContentController : AdminBaseController
    {

        #region Constractor

        private readonly IContentService _service;

        public ContentController(IContentService service)
        {
            _service = service;
        }

        #endregion


        [HttpGet("ListArticle")]
        public async Task<IActionResult> ListArticle()
        {
            return View();
        }

        [HttpGet("AddArticle")]
        public async Task<IActionResult> AddArticle()
        {
            return View();
        }

        [HttpPost("AddArticle"),ValidateAntiForgeryToken]
        public async Task<IActionResult> AddArticle(ArticleViewModel add,IFormFile image,IFormFile thumb)
        {
            if (ModelState.IsValid)
            {
                var art = await _service.AddArticle(add, image, thumb);
                switch (art)
                {
                    case AddArticleResult.ImageError:
                        TempData[ErrorMessage] = "تصویر اصلی الزامی است";
                        break;
                    case AddArticleResult.ThumbError:
                        TempData[ErrorMessage] = "تصویر فرعی الزامی است";
                        break;
                    case AddArticleResult.Error:
                        TempData[ErrorMessage] = "عملیات با خطا مواجه شد";
                        break;
                    case AddArticleResult.Success:
                        TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                        return RedirectToAction("ListArticle");
                }
            }
            return View();
        }
    }
}
