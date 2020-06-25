using AXADev.Exams.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace AXADev.Exams.Helpers {
    public class RequestAPIHelper {
        public static object Send(RequestAPI request) {
            var jObject = new JObject();
            try {
                var req = (HttpWebRequest)WebRequest.Create(new Uri(request.Uri));

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                req.Method = request.Method;
                req.ContentType = request.ContentType;
                foreach (var item in request.Headers) {
                    req.Headers.Add(item.Property, item.Value);
                }


                var bodyString = JsonConvert.SerializeObject(request.Body);
                var encoding = new ASCIIEncoding();
                var byteArray = encoding.GetBytes(bodyString);
                req.ContentLength = byteArray.Length;

                using (var dataStream = req.GetRequestStream()) {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }

                using (var res = (HttpWebResponse)req.GetResponse()) {
                    using (var sw = res.GetResponseStream()) {
                        if (sw != null) {
                            using (var reader = new StreamReader(sw)) {
                                jObject = JObject.Parse(reader.ReadToEnd());
                            }
                        }
                        sw.Dispose();
                    }
                }

            } catch (Exception e) {
                var bodyObj = new { errorMessage = e.Message };
                var bodyString = JsonConvert.SerializeObject(bodyObj);
                jObject = JObject.Parse(bodyString);
            }
            return jObject;

        }
    }
}