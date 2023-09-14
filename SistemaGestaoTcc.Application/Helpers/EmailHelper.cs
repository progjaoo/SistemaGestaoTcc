namespace SistemaGestaoTcc.Application.Helpers
{
    public class EmailHelper
    {
        //public EmailHelper(string assunto, string linkEndereco, string conteudo, string botaoNome)
        //{
        //    Assunto = assunto;
        //    LinkEndereco = linkEndereco;
        //    Conteudo = conteudo;
        //    BotaoNome = botaoNome;
        //}

        //public string Assunto { get; set; }
        //public string LinkEndereco { get; set; }
        //public string Conteudo { get; set; }
        //public string BotaoNome { get; set; }

        public string GeralHTML(string linkEndereco, string conteudo, string botaoNome)
        {
            var newEmail = new EmailHelper();

            var gerarHtml = File.ReadAllText("email.html");
            

            gerarHtml = gerarHtml.Replace("[LinkEndereco]", linkEndereco);
            gerarHtml = gerarHtml.Replace("[Conteudo]", conteudo);
            gerarHtml = gerarHtml.Replace("[BotaoNome]", botaoNome);

            return gerarHtml;
        }
    }
}
