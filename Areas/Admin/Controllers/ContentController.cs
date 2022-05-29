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


        #region Article

        public async Task<IActionResult> ListArticle()
        {
            var ar =await _service.GetAllArticle();
            return View(ar);
        }


        [HttpGet]
        public async Task<IActionResult> AddArticle()
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> AddArticle(ArticleViewModel add,IFormFile image)
        {
            if (ModelState.IsValid)
            {
                var art = await _service.AddArticle(add, image);
                switch (art)
                {
                    case AddArticleResult.ImageError:
                        TempData[ErrorMessage] = "تصویر اصلی الزامی است";
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

        #endregion

        #region MainGroup

        public async Task<IActionResult> GroupList()
        {
            var gr = await _service.GetAllManiGroupForAdmin();
            return View(gr);
        }
        [HttpGet]
        public async Task<IActionResult> AddMainGroup()
        {
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMainGroup(MainGroupViewModel group)
        {
            if (ModelState.IsValid)
            {
                var res = await _service.AddMainGroup(group);
                switch (res)
                {
                    case AddMAinGroupResult.Error:
                        TempData[ErrorMessage] = "عملیات با خطا مواجه شد";
                        TempData[InfoMessage] = "داده های خود را مجددا بررسی کنید";
                        break;
                    case AddMAinGroupResult.Success:
                        TempData[SuccessMessage] = "دسته ی جدید با موفقیت اضافه شد";
                        return RedirectToAction("GroupList");
                }
            }
            return View(group);
        }

        #endregion
    }
}
