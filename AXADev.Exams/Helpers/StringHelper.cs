using System;
using System.IO;
using System.Web;

namespace AXADev.Exams.Helpers {
    public class StringHelper {
        public static string FileToBase64String(HttpPostedFileBase file) {
            byte[] fileBytes = new byte[file.ContentLength];
            using (var theReader = new BinaryReader(file.InputStream)) {
                fileBytes = theReader.ReadBytes(file.ContentLength);
            }
            return Convert.ToBase64String(fileBytes);
        }
    }
}