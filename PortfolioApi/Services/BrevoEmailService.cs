using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Model;
using System.Net;
using System.Net.Mail;
using System.Diagnostics;

namespace Portfolio.Services;

public class BrevoEmailService
{
    private readonly string? _smtpServer;
    private readonly int _port;
    private readonly string? _username;
    private readonly string? _password;

    public BrevoEmailService(IConfiguration config)
    {
        _smtpServer = config["EmailSettings:SmtpServer"];
        _port = int.Parse(config["EmailSettings:Port"]!);
        _username = config["EmailSettings:Username"];
        _password = config["EmailSettings:Password"];
    }


    public async Task<string> SendEmailAsync(string toEmail, string subject, string body)
    {
        if (_username == null)
            return "";

        using (var client = new SmtpClient(_smtpServer, _port))
        {
            client.Credentials = new NetworkCredential(_username, _password);
            client.EnableSsl = true;  // Use TLS
            client.UseDefaultCredentials = false;

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_username, "Omphulusa Mashau's Portfolio"),  // Sender name
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            mailMessage.To.Add(toEmail);

            await client.SendMailAsync(mailMessage);

            return "Success";
        }
    }

}

/*
public class EmailSender
{
    public static void SendEmail(string senderEmail, string senderName,
        string receiverEmail, string receiverName, string subject, string message)
    {
        var apiInstance = new TransactionalEmailsApi();
        SendSmtpEmailSender sender = new SendSmtpEmailSender(senderName, senderEmail);

        SendSmtpEmailTo receiver1 = new SendSmtpEmailTo(receiverEmail, receiverName);
        List<SendSmtpEmailTo> To = new();
        To.Add(receiver1);

        string? HtmlContent = null;
        string TextContent = message;

        try
        {
            var sendSmtpEmail = new SendSmtpEmail(sender, To, null, null, HtmlContent, TextContent, subject);
            CreateSmtpEmail result = apiInstance.SendTransacEmail(sendSmtpEmail);
            Debug.WriteLine("Email result" + result);
            Console.WriteLine("Email result" + result);
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Email result" + ex.Message);
            Console.WriteLine("Email result" + ex.Message);
        }
    }

}
*/