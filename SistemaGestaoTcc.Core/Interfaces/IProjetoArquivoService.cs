using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SistemaGestaoTcc.Core.Interfaces
{
    public interface IProjetoArquivoService
    {
        Task EnviarArquivoParaProjeto(int idProjeto, IFormFile file);
        Task EnviarImagemProjeto(int idProjeto, IFormFile file);
        Task EnviarImagemUsuario(int idUsuario, IFormFile file);
    }
}
