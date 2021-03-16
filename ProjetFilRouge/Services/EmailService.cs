using ProjetFilRouge.Dtos.EmailDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ProjetFilRouge.Services
{
    public class EmailService
    {
        private const string ADRESSE_EMAIL_EXPEDITEUR = "projetfilrougerecrutement@gmail.com";

        /// <summary>
        ///     Envoi un email smtp
        /// </summary>
        /// <param name="sendEmail">SendEmailDto</param>
        /// <returns>true si le mail à bien été envoyé</returns>
        public bool SendEmail(SendEmailDto sendEmail)
        {
            MailMessage message = new MailMessage(ADRESSE_EMAIL_EXPEDITEUR, sendEmail.Email);
            message.Subject = sendEmail.Subject;
            message.Body = sendEmail.Message;

            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential(ADRESSE_EMAIL_EXPEDITEUR, "projetFilRouge");
                // send the email
                try
                {
                    smtp.Send(message);
                    return true;
                }
                catch
                {
                    return false;
                }
            }

        }
    }
}
