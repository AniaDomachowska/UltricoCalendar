using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace UltricoGoogleCalendar.Jobs
{
    public class EventScheduleJob
    {
        public async Task Execute(EventScheduleArgs jobArgs)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("from@wp.pl"));
            email.To.Add(new MailboxAddress(jobArgs.Email));
            email.Subject = $"Calendar event reminder: {jobArgs.Event.Title}";

            var body = new BodyBuilder
            {
                HtmlBody = jobArgs.Event.Description
            };

            email.Body = body.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (sender, certificate, chain, errors) => true;
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                // Start of provider specific settings
                await client.ConnectAsync("smtp.host", 587, false).ConfigureAwait(false);
                await client.AuthenticateAsync("username", "password").ConfigureAwait(false);
                // End of provider specific settings

                await client.SendAsync(email).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);
            }
        }
    }
}