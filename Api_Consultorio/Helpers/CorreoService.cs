using Microsoft.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace Api_Consultorio.Helpers
{
    public class CorreoService
    {
        string[] Operador = new string[2];
        //List<Operador> listaOperador= new();


        public CorreoService()//Solamente es ejemplo del sendMail();
        {
            sendMail("a1anchavez@hotmail.com","Prueba1","Mensaje de prueba nada mas");
        }

        public string sendMail(string to, string asunto, string body) {
            string msge;
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
