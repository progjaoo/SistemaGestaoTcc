namespace SistemaGestaoTcc.Application.Helpers
{
    public class EmailHelper
    {
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
