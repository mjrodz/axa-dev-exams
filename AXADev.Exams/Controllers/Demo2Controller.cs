using AXADev.Exams.Helpers;
using AXADev.Exams.Models;
using Newtonsoft.Json.Linq;
using System.Web;
using System.Web.Mvc;


namespace AXADev.Exams.Controllers {
    public class Demo2Controller : Controller {
        // GET: Demo2
        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult SubmitResult(HttpPostedFileBase file) {

            var request = new RequestAPI {
                Uri = "https://goodmorning-axa-dev.azure-api.net/upload",
                Method = "POST",
                ContentType = "application/json",
                Body = new {
                    file = new {
                        mine = "application/pdf",
                        data = StringHelper.FileToBase64String(file)
                    }
                }
            };

            request.Headers.Add(new RequestAPIHeader() {
                Property = "x-axa-api-key",
                Value = "2838c637-5424-4889-b09d-af3cc149c0fe"
            });

            var result = JObject.FromObject(RequestAPIHelper.Send(request));

            return View(result);
        }

    }
}