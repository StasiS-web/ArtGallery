using ArtGallery.Core.Messaging.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Core.Messaging
{
    public class NullMessageSender : IEmailSender
    {
        public Task SendEmailAsync(string from, string fromName, string to, string subject, string htmlContent, IEnumerable<EmailAttachment> attachments = null)
        {
            return Task.CompletedTask;
        }
    }
}
