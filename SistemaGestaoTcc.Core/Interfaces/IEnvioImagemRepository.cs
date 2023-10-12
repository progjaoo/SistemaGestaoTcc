using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SistemaGestaoTcc.Core.Interfaces
{
    public interface IEnvioImagemRepository 
    {
        Task UploadImage(IFormFile file, string nomeArquivoBlob);
        Task SaveChangesAsync();
    }
}
