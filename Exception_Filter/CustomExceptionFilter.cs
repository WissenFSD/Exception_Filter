using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Net.Mail;

namespace Exception_Filter
{
    // IException Filter interfacesinden kalıtmammız gerekmektedir.
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // Exception Filter : Uygulamanın herhangi bir yerinde exception olduğunda, buraya düşecek demektir
            // Uygulamalarınızın exceptionlarını takip edebilmek için, Log kaydı atabilir, Bildirim için email gönderebilirsiniz.

            // Exception olduğunda size email atan bir sistem yapalım 


            // Yakalanan exceptionları, nasıl yakalayabilirim.
            //context.Exception;

            var ex = context.Exception;

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.Credentials = new NetworkCredential("wissenfsd@gmail.com", "Bright**");
            client.EnableSsl = true;
            client.UseDefaultCredentials = true;

            MailMessage message = new MailMessage("wissenfsd@gmail.com", "serhatebren34@gmail.com");

            message.Subject = "Web Sitenden hata alındı";
            message.Body = "Web Siteden, şu hata alındı : " + ex.Message;
            
            //message.To.Add(new MailAddress("serhatebren34@gmail.com"));

            //email message hazır gönderelim

            client.Send(message);


        }
    }
}
