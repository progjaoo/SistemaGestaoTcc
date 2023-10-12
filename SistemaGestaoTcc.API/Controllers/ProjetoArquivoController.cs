﻿using Microsoft.AspNetCore.Mvc;
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
        public ProjetoArquivoController(IProjetoArquivoRepository projetoArquivoRepository, IProjectRepository projectRepository)
        {
            _projetoArquivoRepository = projetoArquivoRepository;
            _projectRepository = projectRepository;
        }

        [HttpPost("enviarArquivos")]
        public async Task<IActionResult> EnviarArquivoParaProjeto(int idProjeto, IFormFile file)
        {
            try
            {
                var projeto = await _projectRepository.GetById(idProjeto);
                if (projeto == null)
                {
                    return NotFound("Projeto não encontrado.");
                }
                if (file == null || file.Length == 0)
                {
                    return BadRequest("Nenhum arquivo enviado.");
                }
                string nomeArquivoBlob = $"{idProjeto}-{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

                await _projetoArquivoRepository.UploadArquivos(file, nomeArquivoBlob);

                var projetoArquivo = new ProjetoArquivo
                {
                    IdProjeto = idProjeto,
                    DiretorioArquivo = nomeArquivoBlob,
                    CriadoEm = DateTime.Now
                };

                projeto.ProjetoArquivo.Add(projetoArquivo);

                await _projetoArquivoRepository.SaveChangesAsync();

                return Ok("Arquivo enviado com sucesso.");
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