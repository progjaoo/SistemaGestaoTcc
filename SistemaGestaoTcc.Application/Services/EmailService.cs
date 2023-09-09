using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using SendGrid.Helpers.Mail.Model;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;
using static System.Net.WebRequestMethods;

namespace SistemaGestaoTcc.Application.Services
{
    public class EmailService
    {
        public async Task ConviteEmailAsync(EmailAddress paraEmail, string assunto, string content, string htmlContent)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var email = new EmailAddress("joaomarcosvalente@outlook.com", "SistemaTcc");

            var msg = MailHelper.CreateSingleEmail(email, paraEmail, assunto, content, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
