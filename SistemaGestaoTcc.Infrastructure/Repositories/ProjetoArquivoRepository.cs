using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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

        public async Task<byte[]> DownloadBlobAsync(string nomeArquivo)
        {
            var container = new BlobContainerClient(_configuration["Blob:ConnectionString"], _configuration["Blob:ContainerName"]);
            var blobClient = container.GetBlobClient(nomeArquivo);

            BlobDownloadInfo blobDownloadInfo = await blobClient.DownloadAsync();

            using (MemoryStream memoryStream = new MemoryStream())
            {
                await blobDownloadInfo.Content.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }

        public async Task<List<ProjetoArquivo>> GetAllAsync()
        {
            return await _dbcontext.ProjetoArquivo.ToListAsync();
        }
        public async Task<List<string>> ListBlobFilesAsync()
        {
            var container = new BlobContainerClient(_configuration["Blob:ConnectionString"], _configuration["Blob:ContainerName"]);

            var blobs = new List<string>();

            await foreach (BlobItem blobItem in container.GetBlobsAsync())
            {
                blobs.Add(blobItem.Name);
            }

            return blobs;
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
