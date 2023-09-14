using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SendGrid;
using SendGrid.Helpers.Mail;
using SistemaGestaoTcc.Application.Helpers;

namespace SistemaGestaoTcc.Application.Services
{
    public class EmailService
    {

        public async Task ConviteEmailAsync(EmailAddress paraEmail, string assunto, string linkEndereco, string conteudo, string botaoNome)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var email = new EmailAddress("joaomarcosvalente@outlook.com", "SistemaTcc");

            var content = "";

            var emailHelpers = new EmailHelper();

            var htmlContent = emailHelpers.GeralHTML(linkEndereco, conteudo, botaoNome);

            var msg = MailHelper.CreateSingleEmail(email, paraEmail, assunto, content, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
