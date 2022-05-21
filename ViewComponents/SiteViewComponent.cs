using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RockFord.Application.Services.Interfaces;

namespace RockFord.Web.ViewComponents
{
    #region LastArticle

    public class LastArticleViewComponent : ViewComponent
    {
        private readonly IContentService _service;

        public LastArticleViewComponent(IContentService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var source = await _service.GetAllArticleByCreateDate();
            var enumerable = source.Take(6);
            return View("LastArticle", enumerable);
        }

    }

    #endregion

    #region SiteHeader

    public class SiteHeaderViewComponent:ViewComponent
    {
        private readonly ISiteService _siteService;

        public SiteHeaderViewComponent(ISiteService siteService)
        {
            _siteService = siteService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.siteInfo = await _siteService.GetActiveSiteIno();
            return View("SiteHeader");
        }
    }

    #endregion

    #region SiteFooter

    public class SiteFooterViewComponent : ViewComponent
    {
        private readonly ISiteService _siteService;

        public SiteFooterViewComponent(ISiteService siteService)
        {
            _siteService = siteService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.siteInfo = await _siteService.GetActiveSiteIno();
            return View("SiteFooter");
        }
    }

    #endregion

    #region SiteSlider

    public class SiteSliderViewComponent : ViewComponent
    {
        private readonly ISiteService _siteService;

        public SiteSliderViewComponent(ISiteService siteService)
        {
            _siteService = siteService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var source= await _siteService.GetSiteSlider();
            return View("SiteSlider",source);
        }
    }

    #endregion
}