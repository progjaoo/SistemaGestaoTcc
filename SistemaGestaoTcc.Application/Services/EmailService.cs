using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.SqlServer.Server;
using SendGrid;
using SendGrid.Helpers.Mail;
using SendGrid.Helpers.Mail.Model;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace SistemaGestaoTcc.Application.Services
{
    public class EmailService
    {
        public static string GerarHTML(string nomeUsuario, string nomeProjeto)
        {
            var htmlBase = "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <style>\r\n        table {\r\n            width: 100%;\r\n            max-width: 590px;\r\n            margin: 0 auto;\r\n            border-collapse: collapse;\r\n            background-size: auto;\r\n            font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif;\r\n        }\r\n\r\n        td {\r\n            padding: 0;\r\n            text-align: center;\r\n            border-top: 0;\r\n            border-right: 0;\r\n            border-bottom: 0;\r\n            border-left: 0;\r\n            padding-bottom: 20px;\r\n        }\r\n\r\n        .header {\r\n            background-color: #3476c0;\r\n            background-size: cover;\r\n            border-radius: 50px;\r\n            color: #000;\r\n            width: 590px;\r\n        }\r\n        .title {\r\n            font-weight: 700;\r\n            color: #fff;\r\n            font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif;\r\n            font-size: 34px;\r\n            letter-spacing: normal;\r\n            line-height: 120%;\r\n            text-align: center;\r\n            margin: 0;\r\n            padding-top: 10px;\r\n            padding-bottom: 10px;\r\n        }\r\n        .image {\r\n            padding-top: 25px;\r\n            padding-bottom: 15px;\r\n            width: 100%;\r\n            padding-right: 0;\r\n            padding-left: 0;\r\n        }\r\n        .button {\r\n            text-decoration: none;\r\n            display: inline-block;\r\n            color: #ffffff;\r\n            background-color: #201e4f;\r\n            border-radius: 15px;\r\n            width: auto;\r\n            font-weight: 400;\r\n            padding: 10px;\r\n            font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif;\r\n            font-size: 18px;\r\n            text-align: center;\r\n            cursor: pointer;\r\n        }\r\n        .paragraph {\r\n            word-break: break-word;\r\n            padding-top: 20px;\r\n            padding-bottom: 20px;\r\n            padding-left: 40px;\r\n            padding-right: 40px;\r\n            color: #fff;\r\n            font-family: Lato, Arial, Sans-serif;\r\n            font-size: 24px;\r\n            font-weight: 400;\r\n            letter-spacing: 0;\r\n            line-height: normal;\r\n            text-align: center;\r\n        }\r\n    </style>\r\n</head>\r\n<body>\r\n    <table class=\"header\">\r\n        <tr>\r\n            <td>\r\n                <h1 class=\"title\">SISTEMA DE GESTÃO DE TCC<img src=\"https://fonts.gstatic.com/s/e/notoemoji/15.0/1f44b/32.png\"></h1>\r\n                <div class=\"image\">\r\n                    <img class=\"image\" alt=\"logo do sistema\">\r\n                </div>\r\n                <p class=\"paragraph\">\r\n                    <strong>[USUÁRIO], você recebeu um convite para participar do projeto [PROJETO].</strong>\r\n                </p>\r\n                <br> <a class=\"button\" href=\"https://pages.github.com/gilbertolgs/SistemaTCC-FrontEnd/convites\">Ir para o Projeto</a> \r\n            </td>\r\n        </tr>\r\n    </table>\r\n</body>";
            htmlBase = htmlBase.Replace("[USUÁRIO]", nomeUsuario);
            htmlBase = htmlBase.Replace("[PROJETO]", nomeProjeto);

            return htmlBase;
        }
        public async Task ConviteEmailAsync(EmailAddress paraEmail, string assunto, string nomeUsuario, string nomeProjeto)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var email = new EmailAddress("joaomarcosvalente@outlook.com", "SistemaTcc");

            var content = "";

            var htmlContent = GerarHTML(nomeUsuario, nomeProjeto);

            var msg = MailHelper.CreateSingleEmail(email, paraEmail, assunto, content, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
