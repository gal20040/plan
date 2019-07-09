using System;
using System.Net.Mail;
using System.Threading;
using System.Web;

namespace IU.Plan.Web.Modules
{
    public class TimerModule : IHttpModule
    {
        static Timer timer;
        readonly long interval = 30000; //30 секунд
        static readonly object synclock = new object();
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
                var hour = 12;
                var minute = 53;
                if (dd.Hour == hour && dd.Minute == minute && sent == false)
                {
                    // настройки smtp-сервера, с которого мы и будем отправлять письмо
                    var smtp = new SmtpClient("smtp.gmail.com", 587)
                    {
                        EnableSsl = true,
                        Credentials = new System.Net.NetworkCredential("gal20040@gmail.com", "")
                    };

                    // наш email с заголовком письма
                    var from = new MailAddress("gal20040@gmail.com", "gal20040");
                    // кому отправляем
                    var to = new MailAddress("gal20040@gmail.com");
                    // создаем объект сообщения
                    var mailMessage = new MailMessage(from, to)
                    {
                        // тема письма
                        Subject = "Test mail",
                        // текст письма
                        Body = "Рассылка сайта"
                    };
                    smtp.Send(mailMessage);
                    sent = true;
                }
                else if (dd.Hour != hour && dd.Minute != minute)
                {
                    sent = false;
                }
            }
        }

        public void Dispose() { }
    }
}