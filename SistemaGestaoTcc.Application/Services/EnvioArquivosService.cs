//using Microsoft.AspNetCore.Http;
//using SistemaGestaoTcc.Core.Models;

//namespace SistemaGestaoTcc.Application.Services
//{
//    public class EnvioArquivosService
//    {
//        private async Task UploadArquivo(IFormFile file)
//        {
//            try
//            {
//                var projeto = await _projectRepository.GetById(idProjeto);
//                if (projeto == null)
//                {
//                    return NotFound("Projeto não encontrado.");
//                }
//                if (file == null || file.Length == 0)
//                {
//                    return BadRequest("Nenhum arquivo enviado.");
//                }
//                string nomeArquivoBlob = $"Projeto-{idProjeto}-{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

//                await _envioImagemRepository.UploadImage(file, nomeArquivoBlob);

//                projeto.Imagem = nomeArquivoBlob;

//                await _projectRepository.SaveChangesAsync();

//                await _envioImagemRepository.SaveChangesAsync();

//                return Ok("Arquivo enviado com sucesso.");
//            }
//            catch (Exception ex)
//            {
//                if (ex.InnerException != null)
//                {
//                    var innerExceptionMessage = ex.InnerException.Message;
//                    Console.WriteLine($"Exceção interna: {innerExceptionMessage}");
//                }

//                Console.WriteLine($"Erro ao salvar as alterações no banco de dados: {ex.Message}");
//                return BadRequest($"Ocorreu um erro ao enviar o arquivo: {ex.Message}");
//            }
//        }
//        public async Task UploadImagensUsuario(Usuario usuario, IFormFile file)
//        {
//            if (usuario == null)
//            {
//                return NotFound("Projeto não encontrado.");
//            }
//            if (file == null || file.Length == 0)
//            {
//                return BadRequest("Nenhum arquivo enviado.");
//            }
//            string nomeArquivoBlob = $"Projeto-{idProjeto}-{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

//            await _envioImagemRepository.UploadImage(file, nomeArquivoBlob);

//            projeto.Imagem = nomeArquivoBlob;

//            await _projectRepository.SaveChangesAsync();

//            await _envioImagemRepository.SaveChangesAsync();

//            return Ok("Arquivo enviado com sucesso.");
//        }
//        public async Task UploadArquivoProjeto(Projeto projeto, IFormFile file, string uploadType)
//        {

//        }
//    }
//}
