using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.Security;

namespace Laptop.Models
{
    public class EmailService
    {        
        public static void SendMail(string to, string strSubject, string strContent)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(to);
            mailMessage.From = new MailAddress("vodanhqt@gmail.com");
            mailMessage.Subject = strSubject;
            mailMessage.Body = strContent;
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.Credentials = new System.Net.NetworkCredential("vodanhqt@gmail.com", "coganghochanh");
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
            //Response.Write("E-mail sent!");

        }
        //public static string MahoaMD5(string usn)
        //{
        //    string chuoi = FormsAuthentication.HashPasswordForStoringInConfigFile(usn, "SHA1");
        //    return chuoi;
        //}
    }
}