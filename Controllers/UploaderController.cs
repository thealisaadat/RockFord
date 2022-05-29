using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RockFord.Application.Extensions;
using RockFord.Application.Utility;

namespace RockFord.Web.Controllers
{
    public class UploaderController : BaseController
    {

        [HttpPost]
        public IActionResult UploadImage(IFormFile upload, string ckEditorFunName, string ckEditor, string langCode)
        {
            if (upload.Length <= 0) return null;
            if (!upload.IsImage())
            {
                var notImageMessage = "لطفا یک تصویر انتخاب کنید";
                var notImage =
                    JsonConvert.DeserializeObject("{'uploaded':0,'error':{'message':\"" + notImageMessage + "\"}}");
                return Json(notImage);
            }

            var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();
            upload.AddImageToServer(fileName, PathExtensions.UploadImageToServer, null, null);
            return Json(new
            {
                uploaded = true,
                url = $"{PathExtensions.UploadImage}{fileName}"
            });
        }
    }
}
