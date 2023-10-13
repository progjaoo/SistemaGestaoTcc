using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;
using SistemaGestaoTcc.Infrastructure.Repositories;

public class ProjetoArquivoService : IProjetoArquivoService
{
    private readonly IProjectRepository _projectRepository;
    private readonly IProjetoArquivoRepository _projetoArquivoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IEnvioImagemRepository _envioImagemRepository;
    public ProjetoArquivoService(IProjectRepository projectRepository, IProjetoArquivoRepository projetoArquivoRepository, IEnvioImagemRepository envioImagemRepository, IUserRepository userRepository)
    {
        _projectRepository = projectRepository;
        _projetoArquivoRepository = projetoArquivoRepository;
        _envioImagemRepository = envioImagemRepository;
        _userRepository = userRepository;
    }

    public async Task EnviarArquivoParaProjeto(int idProjeto, IFormFile file)
    {
        var projeto = await _projectRepository.GetById(idProjeto);
        if (projeto == null)
        {
            throw new NotFoundException("Projeto não encontrado.");
        }
        if (file == null || file.Length == 0)
        {
            throw new BadRequestException("Nenhum arquivo enviado.");
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
    }

    public async Task EnviarImagemProjeto(int idProjeto, IFormFile file)
    {
        var projeto = await _projectRepository.GetById(idProjeto);
        if (projeto == null)
        {
            throw new NotFoundException("Projeto não encontrado.");
        }
        if (file == null || file.Length == 0)
        {
            throw new BadRequestException("Nenhum arquivo enviado.");
        }
        string nomeArquivoBlob = $"Projeto-{idProjeto}-{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

        await _envioImagemRepository.UploadImage(file, nomeArquivoBlob);

        projeto.Imagem = nomeArquivoBlob;
        await _projectRepository.SaveChangesAsync();

        await _envioImagemRepository.SaveChangesAsync();
    }

    public async Task EnviarImagemUsuario(int idUsuario, IFormFile file)
    {
        var usuario = await _userRepository.GetById(idUsuario);
        if (usuario == null)
        {
            throw new NotFoundException("Usuário não encontrado.");
        }
        if (file == null || file.Length == 0)
        {
            throw new BadRequestException("Nenhum arquivo enviado.");
        }
        string nomeArquivoBlob = $"Usuario-{idUsuario}-{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

        await _envioImagemRepository.UploadImage(file, nomeArquivoBlob);

        usuario.Imagem = nomeArquivoBlob;

        await _userRepository.SaveChangesAsync();
        await _envioImagemRepository.SaveChangesAsync();
    }
}