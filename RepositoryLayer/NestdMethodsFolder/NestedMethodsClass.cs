using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.NestdMethodsFolder
{
    public class NestedMethodsClass
    {
        public static string EncryptPassword(string password)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string DecryptPassword(string encryptedPassword)
        {
            byte[] encodedBytes = Convert.FromBase64String(encryptedPassword);
            return Encoding.UTF8.GetString(encodedBytes);
        }


        //SendMail Logic

        public static void sendMail(String ToMail, String otp)
        {
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            try
            {
                mailMessage.From = new System.Net.Mail.MailAddress("tejasgowda555@outlook.com", "FUNDOO NOTES");
                mailMessage.To.Add(ToMail);
                mailMessage.Subject = "Change password for Fundoo Notes";
                mailMessage.Body = "This is your otp please enter to change password " + otp;
                mailMessage.IsBodyHtml = true;
                System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient("smtp-mail.outlook.com");

                // Specifies how email messages are delivered. Here Email is sent through the network to an SMTP server.
                smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;

                // Set the port for Outlook's SMTP server
                smtpClient.Port = 587; // Outlook SMTP port for TLS/STARTTLS

                // Enable SSL/TLS
                smtpClient.EnableSsl = true;

                string loginName = "tejasgowda555@outlook.com";
                string loginPassword = "ramtej@05S";

                System.Net.NetworkCredential networkCredential = new System.Net.NetworkCredential(loginName, loginPassword);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = networkCredential;

                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught: " + ex.Message);
            }
            finally
            {
                mailMessage.Dispose();
            }
        }
        //eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L
        //2NsYWltcy9lbWFpbGFkZHJlc3MiOiJzdHJpbmdAZ21haWwuY29tIiwiZXhwIjoxNzEzMTM5NjU3LCJpc3MiOiJodHRwczovL2xvY2
        //FsaG9zdDo0NDM0OC8iLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo0NDM0OC8ifQ.arCkgL_yEnfXCqPJZSbXsSqS2ER2Cf9zHpkRvMCyacY
    }
}
