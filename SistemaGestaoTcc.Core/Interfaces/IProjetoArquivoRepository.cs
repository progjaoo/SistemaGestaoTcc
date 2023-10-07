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
        Task AddAsync(ProjetoArquivo projetoArquivo);
        Task Upload(IFormFile file, string nomeArquivoBlob);
        Task SaveChangesAsync();
    }
}
