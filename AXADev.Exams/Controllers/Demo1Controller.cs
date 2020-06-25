using AXADev.Exams.Helpers;
using AXADev.Exams.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Web.Mvc;


namespace AXADev.Exams.Controllers {
    public class Demo1Controller : Controller {
        // GET: Demo1
        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult SubmitResult(FormCollection form) {

            var request = new RequestAPI {
                Uri = "https://goodmorning-axa-dev.azure-api.net/register",
                Method = "POST",
                ContentType = "application/json",
                Body = new {
                    Name = Convert.ToString(form["name"]),
                    Email = Convert.ToString(form["email"]),
                    Mobile = Convert.ToString(form["mobile"]),
                    PositionApplied = Convert.ToString(form["position"])
                }
            };

            var result = JObject.FromObject(RequestAPIHelper.Send(request));

            return View(result);
        }

    }
}