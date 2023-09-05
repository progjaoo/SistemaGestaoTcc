using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SistemaGestaoTcc.Application.ViewModels
{
    public class ProjectCommentViewModel 
    {
        public ProjectCommentViewModel(int id, string conteudo, DateTime? criadoEm)
        {
            Id = id;
            Conteudo = conteudo;
            CriadoEm = criadoEm;
        }

        public int Id { get; set; }

        public string Conteudo { get; set; }

        public DateTime? CriadoEm { get; set; }
    }
}
