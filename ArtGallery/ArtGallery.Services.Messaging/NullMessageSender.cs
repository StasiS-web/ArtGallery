namespace ArtGallery.Services.Messaging
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ArtGallery.Services.Messaging.Contracts;

    public class NullMessageSender : IEmailSender
    {
        public Task SendEmailAsync(string from, string fromName, string to, string subject, string htmlContent, IEnumerable<EmailAttachment> attachments = null)
        {
            return Task.CompletedTask;
        }
    }
}