using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace PortalPrivado.Web.Utilidades
{
    public class Comunicacion
    {
        public void sendEmail(String html, String EmailDestino)
        {
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com");
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            System.Net.NetworkCredential credentials =
                new System.Net.NetworkCredential(Recursos.emailsend, Recursos.passSend);
            client.EnableSsl = true;
            client.Credentials = credentials;

            try
            {
                var mail = new MailMessage(Recursos.emailsend.Trim(), EmailDestino.Trim());
                mail.Subject = "CONFIRMACIÓN DE SU CITA MÉDICA";
                mail.IsBodyHtml = true;
                mail.Body = html;               
                client.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public void sendEmailExam(String html, String EmailDestino)
        {
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com");
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            System.Net.NetworkCredential credentials =
                new System.Net.NetworkCredential(Recursos.emailsend, Recursos.passSend);
            client.EnableSsl = true;
            client.Credentials = credentials;

            try
            {
                var mail = new MailMessage(Recursos.emailsend.Trim(), EmailDestino.Trim());
                mail.Subject = "Exámenes Clínica Universidad de los Andes";
                mail.IsBodyHtml = true;
                mail.Body = html;
                client.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}