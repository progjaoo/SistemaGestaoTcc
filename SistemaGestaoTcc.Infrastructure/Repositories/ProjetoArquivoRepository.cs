using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Infrastructure.Repositories
{
    public class ProjetoArquivoRepository : IProjetoArquivoRepository
    {
        private readonly SistemaTccContext _dbcontext;
        private readonly IConfiguration _configuration;
        public ProjetoArquivoRepository(SistemaTccContext dbcontext, IConfiguration configuration)
        {
            _dbcontext = dbcontext;
            _configuration = configuration;
        }

        public async Task AddAsync(ProjetoArquivo projetoArquivo)
        {
            await _dbcontext.ProjetoArquivo.AddAsync(projetoArquivo);
        }

        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }

        public async Task Upload(IFormFile file, string nomeArquivoBlob)
        {
            using var stream = new MemoryStream();
            file.CopyTo(stream);
            stream.Position = 0;

            var container = new BlobContainerClient(_configuration["Blob:ConnectionString"], _configuration["Blob:ContainerName"]);

            await container.UploadBlobAsync(file.FileName, stream);
        }
    }
}
