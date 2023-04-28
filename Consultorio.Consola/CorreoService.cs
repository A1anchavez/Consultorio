using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Consola
{
    public class CorreoService
    {
        public string sendMail(string to, string asunto, string body)
        {
            string msge = "Verifica la conexion a internet y que tus datos sean correctos";
            string from = "alan.chavez@techsoft.com.mx";
            string contraseña = "Chv3z-2022";
            string displayName = "Testing";
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from, displayName);
                mail.To.Add(to);

                mail.Subject = asunto;
                mail.Body = body;
                mail.IsBodyHtml = true;

                SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                client.Credentials = new NetworkCredential(from, contraseña);
                client.EnableSsl = true;//En caso de que tu servidor de correo no utilice cifrado SSL, poner en false

                client.Send(mail);
                msge = "¡Correo enviado exitosamente!";
            }
            catch (Exception ex)
            {
                msge = ex.Message + ". Verifica la conexion a internet y que tus datos sean correctos";
            }
            return msge;
        }
    }
}
