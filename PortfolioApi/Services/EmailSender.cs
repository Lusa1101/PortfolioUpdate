using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using System.Net;
//using System.Net.Mail;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;

namespace Portfolio.Services
{
    public class MailKitSender
    {
        private readonly IConfiguration _configuration;

        //Mail variables
        string? password = string.Empty;
        string? sender;
        string? receiver = string.Empty;
        string subject = "Omphulusa Mashau's Portfolio: New Message";

        public MailKitSender (IConfiguration configuration)
        {
            _configuration = configuration;

            //Update the variables
            sender = "lusa96610@gmail.com";//Environment.GetEnvironmentVariable("Email_Sender");//_configuration["EMAIL_CONFIGURATION:SENDER"];
            password = "sazd blfx ekui lgzt";//Environment.GetEnvironmentVariable("Email_Password");//_configuration["EMAIL_CONFIGURATION:PASSWORD"];
            receiver = "omphu.shau@outlook.com";//Environment.GetEnvironmentVariable("Email_Receiver");//_configuration["EMAIL_CONFIGURATION:RECEIVER"];
        }
        public async Task<string> SendEmail(string text)
        {
            if (sender == null || receiver == null || password == null)
                return "null";

            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(sender));
                email.To.Add(MailboxAddress.Parse(receiver));
                email.Subject = subject;
                email.Body = new TextPart("plain")
                {
                    Text = text
                };

                await Task.Run(async () =>
                {
                    using var smtp = new SmtpClient();
                    //smtp.ServerCertificateValidationCallback = (sender, certificate, chain, e) => true;
                    smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    smtp.Authenticate(sender, password);
                    string result = await smtp.SendAsync(email);
                    smtp.Disconnect(true);

                    return result;
                });

                return "Sending ...";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return ex.Message;
            }
        }
    }

    public class MyBackgroundService : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Debug.WriteLine("Running the email sender");
                await Task.Delay(5000, stoppingToken); // Wait before next execution
            }
        }
    }


    /*
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            var mail = _configuration.GetValue<string>("EMAIL_CONFIGURATION:SENDER");
            var psw = _configuration.GetValue<string>("EMAIL_CONFIGURATION:PASSWORD");
            var host = _configuration.GetValue<string>("EMAIL_CONFIGURATION:HOST");
            var port = _configuration.GetValue<int>("EMAIL_CONFIGURATION:PORT");

            var client = new SmtpClient(host, port);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(mail, psw);
            client.EnableSsl = true;
            

            // Implement your email sending logic here
            return client.SendMailAsync(
                new MailMessage(from: mail!,
                to: email,
                subject,
                message));
        }
    }

    public class AuthMessageSenderOptions
    {
        public string HOST { get; set; } = string.Empty;
        public int PORT { get; set; }
        public string SENDER { get; set; } = string.Empty;
        public string PASSWORD { get; set; } = string.Empty;
        public bool ENABLESSL { get; set; }
        public string RECEIVER { get; set; } = string.Empty;
    }
    */
}