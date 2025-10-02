using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

class Program
{
    static void Main()
    {
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var mailSettings = config.GetSection("MailSettings");

        string smtpServer = mailSettings["SmtpServer"];
        int smtpPort = int.Parse(mailSettings["SmtpPort"]);
        string smtpUsername = mailSettings["SmtpUsername"];
        string smtpPassword = mailSettings["SmtpPassword"];
        string fromEmail = mailSettings["FromEmail"];

        try
        {
            Console.Write("Please enter the recipient's email address: ");
            string toEmail = Console.ReadLine();
            using (var mail = new MailMessage())
            {
                mail.From = new MailAddress(fromEmail);
                mail.To.Add(toEmail); 
                mail.Subject = "Mail Test";
                mail.Body = "Mail Test Content";

                using (var smtp = new SmtpClient(smtpServer, smtpPort))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                    smtp.EnableSsl = true;

                    smtp.Send(mail);
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success");
        }
        catch (SmtpException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"SMTP Error: {ex.StatusCode} - {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"General Error: {ex.Message}");
        }
        finally
        {
            Console.ResetColor();
            Console.WriteLine("Program finished. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
