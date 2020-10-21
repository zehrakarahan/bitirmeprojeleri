using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Core.Utilities.Enum;
using BitirmeProjem.Business.ReturnData;
using BitirmeProjem.Entities.Concrete;
using BitirmeProjem.UI.Areas.Admin.Models;

namespace BitirmeProjem.UI.Helpers
{
    public class TreeViewKategori
    {
        public string id { get; set; }
        public string text { get; set; }
        public int? UstID { get; set; }
        public string Url { get; set; }
        public List<TreeViewKategori> children { get; set; }
    }
    public static class Helper
    {
        public static List<TreeViewKategori> Categories(int? ustID, IList<Kategoriler> list)
        {
            try
            {
                List<TreeViewKategori> dto = new List<TreeViewKategori>();
                dto = list.Select(x => new TreeViewKategori()
                {
                    id = x.ID.ToString(),
                    text = x.Adi,
                    UstID = x.UstID,
                    Url = x.SeoUrl
                }).Where(y => y.UstID == ustID).ToList();
                foreach (var item in dto)
                {
                    item.children = Categories(Convert.ToInt32(item.id), list).ToList();
                }
                return dto;
            }
            catch (Exception)
            {

                return null;
            }
            
        }

        public static void setTempData(Controller ctrl, string key, bool succes, string message)
        {
            ctrl.TempData[key] = new StatusData { Message = message, Status = succes ? Enums.StatusEnum.Successful : Enums.StatusEnum.Error };
        }

        public static StatusData SetModelTempData(Controller ctrl, string key, BaseModel model = null)
        {
            var t = (StatusData)ctrl.TempData[key];
            if (ctrl.TempData[key] == null)
            {
                return null;
            }
            if (model != null)
            {

                model.Message = t.Message;
                model.Status = t.Status;
            }
            ctrl.TempData.Remove(key);
            return t;
        }
        public static string ToSeoFriendly(string title, int maxLength)
        {
            title = title.ToLower();
            title = Regex.Replace(title, "ş", "s");
            title = Regex.Replace(title, "ı", "i");
            title = Regex.Replace(title, "ö", "o");
            title = Regex.Replace(title, "ü", "u");
            title = Regex.Replace(title, "ç", "c");
            title = Regex.Replace(title, "ğ", "g");
            var match = Regex.Match(title, "[\\w]+");

            StringBuilder result = new StringBuilder("");
            bool maxLengthHit = false;
            while (match.Success && !maxLengthHit)
            {
                if (result.Length + match.Value.Length <= maxLength)
                {
                    result.Append(match.Value + "-");
                }
                else
                {
                    maxLengthHit = true;
                    // Handle a situation where there is only one word and it is greater than the max length.
                    if (result.Length == 0) result.Append(match.Value.Substring(0, maxLength));
                }
                match = match.NextMatch();
            }
            // Remove trailing '-'
            if (result[result.Length - 1] == '-') result.Remove(result.Length - 1, 1);
            return result.ToString();
        }
        public static string turkishToEnglish(string str)
        {
            string returnStr = str;
            char[] oldValue = { 'ö', 'Ö', 'ü', 'Ü', 'ç', 'Ç', 'İ', 'ı', 'Ğ', 'ğ', 'Ş', 'ş' };
            char[] newValue = { 'o', 'O', 'u', 'U', 'c', 'C', 'I', 'i', 'G', 'g', 'S', 's' };
            for (var sayac = 0; sayac < oldValue.Length; sayac++)
            {
                returnStr = returnStr.Replace(oldValue[sayac], newValue[sayac]);
            }
            return returnStr;
        }
        public static string ClearUrl(this string text)
        {
            if (text != null)
            {
                string strReturn = text.ToLower().Trim();
                strReturn = strReturn.Replace("ğ", "g");
                strReturn = strReturn.Replace("Ğ", "G");
                strReturn = strReturn.Replace("ü", "u");
                strReturn = strReturn.Replace("Ü", "U");
                strReturn = strReturn.Replace("ş", "s");
                strReturn = strReturn.Replace("Ş", "S");
                strReturn = strReturn.Replace("ı", "i");
                strReturn = strReturn.Replace("İ", "I");
                strReturn = strReturn.Replace("ö", "o");
                strReturn = strReturn.Replace("Ö", "O");
                strReturn = strReturn.Replace("ç", "c");
                strReturn = strReturn.Replace("Ç", "C");
                strReturn = strReturn.Replace("-", "+");
                strReturn = strReturn.Replace(" ", "+");
                strReturn = strReturn.Trim();
                strReturn = new Regex("[^a-zA-Z0-9+]").Replace(strReturn, "");
                strReturn = strReturn.Trim();
                strReturn = strReturn.Replace("+", "-");
                return strReturn;
            }
            return "";
        }
        public static string RandomWord()
        {
            string word = "";
            var rnd = new Random();
            for (int i = 0; i < 6; i++)
            {
                word += ((char)rnd.Next('A', 'Z')).ToString();
            }
            return word;
        }
        public static void SendMail(string body, string subject, string[] mailAddress, HttpPostedFileBase file)
        {
            try
            {
                SmtpClient mailClient = new SmtpClient(ConfigurationManager.AppSettings["Host"],
                    int.Parse(ConfigurationManager.AppSettings["Port"]));
                NetworkCredential cred = new NetworkCredential(ConfigurationManager.AppSettings["UserName"], ConfigurationManager.AppSettings["Password"]);
                mailClient.Credentials = cred;
                MailMessage contact = new MailMessage();
                contact.From = new MailAddress(ConfigurationManager.AppSettings["UserName"]);
                contact.Subject = subject;
                contact.IsBodyHtml = true;
                contact.Body = body;
                mailClient.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                if (file != null)
                {
                    Attachment a = new Attachment(file.InputStream, file.FileName);
                    contact.Attachments.Add(a);
                }
                foreach (string item in mailAddress)
                {
                    if (item.Length > 0)
                    {
                        contact.To.Add(item);
                    }
                }
                mailClient.Send(contact);
            }
            catch (Exception ex)
            {

            }

        }
        public static void DeleteFile(string path)
        {
            if (File.Exists(HttpContext.Current.Server.MapPath("~/Content/" + path)))
            {
                File.Delete(HttpContext.Current.Server.MapPath("~/Content/" + path));
            }
        }
        public static string CreateMd5(string input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public static void DeleteFile(string path, string fileName)
        {
            string[] directories = Directory.GetDirectories(HttpContext.Current.Server.MapPath("~/Content/images/" + path));
            foreach (string directory in directories)
            {
                if (File.Exists(directory + "/" + fileName))
                {
                    File.Delete(directory + "/" + fileName);
                }
            }
            if (File.Exists(HttpContext.Current.Server.MapPath("~/Content/images/" + path + "/" + fileName)))
            {
                File.Delete(HttpContext.Current.Server.MapPath("~/Content/images/" + path + "/" + fileName));
            }
        }

        public static string FileName(string fileName, string path)
        {
            string name = Path.GetFileNameWithoutExtension(fileName);
            string ext = Path.GetExtension(fileName);
            name = name.ClearUrl();
            fileName = name + ext;
            if (File.Exists(HttpContext.Current.Server.MapPath("~/Content/" + path + "/" + fileName)))
            {
                fileName = name + Guid.NewGuid() + ext;
                fileName = FileName(fileName, path);
            }
            return fileName;
        }


        public static string SaveImage(HttpPostedFileBase file, string path, int[] w, int[] h, string[] paths)
        {
            string fName = FileName(file.FileName, path + "/Orginal");
            file.SaveAs(HttpContext.Current.Server.MapPath("~/Content/" + path + "/Orginal/" + fName));
            Image imgSource = Image.FromFile(HttpContext.Current.Server.MapPath("~/Content/" + path + "/Orginal/" + fName));
            for (int i = 0; i < w.Length; i++)
            {
                // Image imgList = Imager.Resize(imgSource, w[i], h[i], true);
                Image imgList = ResizeImage(imgSource, w[i], h[i]);
                imgList.Save(HttpContext.Current.Server.MapPath("~/Content/" + path + "/" + paths[i] + "/" + fName));
                imgList.Dispose();
            }
            imgSource.Dispose();
            return fName;
        }
        public static string SaveImage(string img, Image imgSource, string path, int[] w, int[] h, string[] paths)
        {
            string fName = FileName(img, path + "/Orginal");
            for (int i = 0; i < w.Length; i++)
            {
                Image imgList = ResizeImage(imgSource, w[i], h[i]);
                imgList.Save(HttpContext.Current.Server.MapPath("~/Content/" + path + "/" + paths[i] + "/" + fName));
                imgList.Dispose();
            }
            imgSource.Dispose();
            return fName;
        }
        public static Image
                   ResizeImage(Image img, int w, int h)
        {
            int kaynakEn = img.Width;
            int kaynakBoy = img.Height;
            float nPercent;
            var nPercentW = (w / (float)kaynakEn);
            var nPercentH = (h / (float)kaynakBoy);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
            }
            else
            {
                nPercent = nPercentW;
            }
            int hedefEn = (int)(kaynakEn * nPercent);
            int hedefBoy = (int)(kaynakBoy * nPercent);
            Bitmap b = new Bitmap(hedefEn, hedefBoy);
            Graphics g = Graphics.FromImage(b);
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.DrawImage(img, 0, 0, hedefEn, hedefBoy);
            g.Dispose();
            return b;
        }
    }
}