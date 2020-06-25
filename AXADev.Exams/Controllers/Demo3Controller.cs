using AXADev.Exams.Helpers;
using AXADev.Exams.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Web;
using System.Web.Mvc;


namespace AXADev.Exams.Controllers {
    public class Demo3Controller : Controller {
        // GET: Demo3
        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult SubmitResult(FormCollection form) {

            var request = new RequestAPI {
                Uri = "https://goodmorning-axa-dev.azure-api.net/schedule",
                Method = "POST",
                ContentType = "application/json",
                Body = new {
                    ProposedDate = Convert.ToString(form["date"]),
                    ProposedTime = Convert.ToString(form["time"]),
                    Online = "true"
                }
            };

            request.Headers.Add(new RequestAPIHeader() {
                Property = "x-axa-api-key",
                //Value = "4bd85c83-28a9-4681-af5e-297b19bbabac"
                Value = "2838c637-5424-4889-b09d-af3cc149c0fe"
            });

            var result = JObject.FromObject(RequestAPIHelper.Send(request));

            return View(result);
        }

    }
}