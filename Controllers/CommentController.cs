using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RockFord.Application.Services.Interfaces;
using RockFord.DataLayer.DTOs.Contact;

namespace RockFord.Web.Controllers
{
    public class CommentController : BaseController
    {

        #region Constractor

        private readonly ITicketService _service;

        public CommentController(ITicketService service)
        {
            _service = service;
        }

        #endregion

        [HttpGet("{userId},{articleId}")]
        public async Task<IActionResult> AddNewComment(AddTicketViewModel comment,long userId, long articleId)
        {
            if (ModelState.IsValid)
            {
                var res = await _service.AddComment(comment, userId, articleId);
                switch (res)
                {
                    case AddTicketResult.Error:
                        TempData[ErrorMessage] = "نظر خود را در قسمت مربوطه وارد کنید!";
                        break;
                    case AddTicketResult.Success:
                        TempData[SuccessMessage] = "نظر شما با موفقیت ارسال گردید";
                        TempData[InfoMessage] = "پس از تایید ادمین نظر شما بار گذاری میگردد";
                        return Redirect("/");
                }
            }

            return Redirect("/");
        }
    }
}
