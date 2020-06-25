using System.Collections.Generic;

namespace AXADev.Exams.Models {
    public class RequestAPI {
        public RequestAPI() {
            Headers = new List<RequestAPIHeader>();
        }

        public string Uri { get; set; }
        public string Method { get; set; }
        public string ContentType { get; set; }
        public List<RequestAPIHeader> Headers { get; set; }
        public object Body { get; set; }
    }
}