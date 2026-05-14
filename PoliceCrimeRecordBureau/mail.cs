using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

/// <summary>
/// Summary description for mail
/// </summary>
namespace PoliceCrimeRecordBureau
{

    public class mail
    {
        public void sendMail(string toUserMail, string subject, string mailBody)
        {
            try
            {
                string fromEmail = " ";  // Replace with your email
                string appPassword = "";  // Use the app-specific password
                string toEmail = toUserMail;  // Replace with recipient's email

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(fromEmail);
                mail.To.Add(toEmail);
                mail.Subject = subject;
                mail.Body = mailBody;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(fromEmail, appPassword);
                smtp.EnableSsl = true;
                smtp.Send(mail);

                Console.WriteLine("Email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}