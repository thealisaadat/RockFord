using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.CodeAnalysis;
using RockFord.Application.Services.Interfaces;
using RockFord.DataLayer.DTOs.Contact;
using RockFord.DataLayer.DTOs.Content;
using RockFord.DataLayer.Entities.Contents;
using RockFord.Web.PresentationExtensions;

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

        


        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> NewComment(AddTicketViewModel com,long id)
        {

            if (ModelState.IsValid)
            {
                var res = await _service.AddComment(com ,User.GetUserId(), id);
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
