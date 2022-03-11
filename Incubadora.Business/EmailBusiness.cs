using Incubadora.Business.Interface;
using Incubadora.Domain;
using System;
using System.Net;
using System.Net.Mail;

namespace Incubadora.Business
{
    public class EmailBusiness : IEmailBusiness
    {
        public bool SendForgotPasswordEmail(AspNetUsersDomainModel aspNetUserDM)
        {
			try
			{
                MailMessage mailMessage = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();
                mailMessage.From = new MailAddress("xxxxxxxx");
                mailMessage.To.Add(new MailAddress(aspNetUserDM.Email));
                mailMessage.Subject = "Recuperar contraseña";
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = GetForgotPasswordBody(aspNetUserDM);
                smtpClient.Port = 587;
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("xxxxxxxxxx", "xxxxxxx");
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Send(mailMessage);
                return true;
			}
			catch (Exception e)
			{
                return false;
			}
        }

        private string GetForgotPasswordBody(AspNetUsersDomainModel aspNetUserDM)
        {
            string body = "";
            body += "<h1>Hola" + aspNetUserDM.UserName + "</h1></br>";
            body += "<p>Te enviamos este correo porque olvidaste tu contraseña ";
            body += "es importante que no compartas este correo, ya que contiene tus datos personales</p></br>";
            body += "<h4>Datos de tu cuenta</h4>";
            body += "<ul>";
            body += "<li>";
            body += "Usuario: " + aspNetUserDM.UserName;
            body += "Contraseña: " +aspNetUserDM.PasswordHash;
            body += "</li>";
            body += "</ul>";
            return body;
        }
    }
}
