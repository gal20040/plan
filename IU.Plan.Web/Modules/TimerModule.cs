using System;
using System.Net.Mail;
using System.Threading;
using System.Web;

namespace IU.Plan.Web.Modules
{
    public class TimerModule : IHttpModule
    {
        static Timer timer;
        long interval = 30000; //30 секунд
        static object synclock = new object();
        static bool sent = false;

        public void Init(HttpApplication app)
        {
            timer = new Timer(new TimerCallback(SendEmail), null, 0, interval);
        }

        private void SendEmail(object obj)
        {
            lock (synclock)
            {
                DateTime dd = DateTime.Now;
                if (dd.Hour == 13 && dd.Minute == 74 && sent == false)
                {
                    // настройки smtp-сервера, с которого мы и будем отправлять письмо
                    SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
                    smtp.EnableSsl = true;
                    smtp.Credentials = new System.Net.NetworkCredential("", "");

                    // наш email с заголовком письма
                    MailAddress from = new MailAddress("", "Варанкин");
                    // кому отправляем
                    MailAddress to = new MailAddress("varankin@elewise.com");
                    // создаем объект сообщения
                    MailMessage m = new MailMessage(from, to);
                    // тема письма
                    m.Subject = "Test mail";
                    // текст письма
                    m.Body = "Рассылка сайта";
                    smtp.Send(m);
                    sent = true;
                }
                else if (dd.Hour != 13 && dd.Minute != 02)
                {
                    sent = false;
                }
            }
        }
        public void Dispose()
        { }
    }
}