using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Errors.Model;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.API.Controllers
{
    [Route("api/arquivos")]
    [ApiController]
    public class ProjetoArquivoController : ControllerBase
    {
        private readonly IProjetoArquivoRepository _projetoArquivoRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IProjetoArquivoService _projetoArquivoService;
        public ProjetoArquivoController(IProjetoArquivoRepository projetoArquivoRepository, IProjectRepository projectRepository, IProjetoArquivoService projetoArquivoService)
        {
            _projetoArquivoRepository = projetoArquivoRepository;
            _projectRepository = projectRepository;
            _projetoArquivoService = projetoArquivoService;
        }

        [HttpPost("enviarArquivos")]
        public async Task<IActionResult> EnviarArquivoParaProjeto(int idProjeto, IFormFile file)
        {
            try
            {
                await _projetoArquivoService.EnviarArquivoParaProjeto(idProjeto, file);
                return Ok("Arquivo enviado com sucesso.");
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    var innerExceptionMessage = ex.InnerException.Message;
                    Console.WriteLine($"Exceção interna: {innerExceptionMessage}");
                }

                Console.WriteLine($"Erro ao salvar as alterações no banco de dados: {ex.Message}");
                return BadRequest($"Ocorreu um erro ao enviar o arquivo: {ex.Message}");
            }
        }
        [HttpGet("listarArquivos")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var listBlobs = await _projetoArquivoRepository.ListBlobFilesAsync();
                
                return Ok(listBlobs);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao listar os arquivos.: {ex.Message}");                
            }
        }
        [HttpGet("downloadArquivos")]
        public async Task<IActionResult> DownloadArquivoDoBlobStorage(string nomeArquivo)
        {
            try
            {
                var arquivoBytes = await _projetoArquivoRepository.DownloadBlobAsync(nomeArquivo);

                if (arquivoBytes != null)
                {
                    return File(arquivoBytes, "application/octet-stream", nomeArquivo);
                }
                else
                {
                    return NotFound("Arquivo não encontrado.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao baixar o arquivo: {ex.Message}");
            }
        }
    }
}