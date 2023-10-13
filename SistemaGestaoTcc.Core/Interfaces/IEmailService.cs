using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using SendGrid.Helpers.Mail;

namespace SistemaGestaoTcc.Core.Interfaces
{
    public interface IEmailService
    {
        Task ConviteEmailAsync(EmailAddress paraEmail, string assunto, string linkEndereco, string conteudo, string botaoNome);
    }
}
