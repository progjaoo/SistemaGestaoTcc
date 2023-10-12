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
    public class EnvioImagemRepository : IEnvioImagemRepository
    {
        private readonly IConfiguration _configuration;
        private readonly SistemaTccContext _dbcontext;
        public EnvioImagemRepository(IConfiguration configuration, SistemaTccContext dbContext)
        {
            _configuration = configuration;
            _dbcontext = dbContext;
        }

        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();    
        }

        public async Task UploadImage(IFormFile file, string nomeArquivoBlob)
        {
            var blobClient = new BlobClient(_configuration["BlobImagem:ConnectionString"], _configuration["BlobImagem:ContainerName"], nomeArquivoBlob);
            using var stream = new MemoryStream();
            file.CopyTo(stream);
            stream.Position = 0;

            var contentType = file.ContentType;
            var blobHttpHeaders = new BlobHttpHeaders{ ContentType = contentType };
            await blobClient.UploadAsync(stream, blobHttpHeaders);
        }
    }
}
