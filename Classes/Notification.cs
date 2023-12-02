using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

public class Notification
{
    private readonly string smtpServer;
    private readonly int port;
    private readonly string senderEmail;
    private readonly string message;
    private readonly string title;
    public EmailNotification(string smtpServer, int port, string senderEmail)
    {
        this.smtpServer = smtpServer;
        this.port = port;
        this.senderEmail = senderEmail;
        this.message = message;
        this.title = title
    }

    public bool SendEmail(string recipientEmail, string subject, string body)
    {
        try
        {
            using (SmtpClient client = new SmtpClient(smtpServer, port))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(senderEmail);
                client.EnableSsl = true;

                MailMessage mailMessage = new MailMessage(senderEmail, recipientEmail, subject, body);
                client.Send(mailMessage);
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error sending email: " + ex.Message);
            return false;
        }
    }
    public void ShowNotification(string message, string title)
    {
        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
