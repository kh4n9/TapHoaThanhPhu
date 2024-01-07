using DevExpress.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TapHoaThanhPhu.FunctionClass
{
    public class SendMail
    {
        private string username = "thanhphutaphoa@gmail.com";
        private string pass = "rxxnrddlhpytdqdh";

        private string server = "smtp.gmail.com";
        int port = 587;

        public void Send(string toMail, string title, string text)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(username, "Tạp Hóa Thành Phú");
            message.To.Add(new MailAddress(toMail));
            message.Subject = title;
            message.Body = text;

            // gửi mail
            SmtpClient client = new SmtpClient(server, port);
            client.Credentials = new NetworkCredential(username, pass);
            client.EnableSsl = true;
            client.Send(message);

        }
    }
}
