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
        public ProjectCommentViewModel(int id, int idUsuario, UserViewModel usuario, string conteudo, DateTime? criadoEm)
        {
            Id = id;
            IdUsuario = idUsuario;
            Usuario = usuario;
            Conteudo = conteudo;
            CriadoEm = criadoEm;
        }

        public int Id { get; set; }

        public int IdUsuario { get; set; }

        public UserViewModel Usuario { get; set; }

        public string Conteudo { get; set; }

        public DateTime? CriadoEm { get; set; }
    }
}
