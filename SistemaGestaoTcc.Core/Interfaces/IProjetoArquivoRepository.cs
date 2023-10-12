using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Core.Interfaces
{
    public interface IProjetoArquivoRepository
    {
        Task<List<ProjetoArquivo>> GetAllAsync();
        Task<List<string>> ListBlobFilesAsync();
        Task AddAsync(ProjetoArquivo projetoArquivo);
        Task UploadArquivos(IFormFile file, string nomeArquivoBlob);
        Task<byte[]> DownloadBlobAsync(string nomeArquivo);
        Task SaveChangesAsync();
    }
}
