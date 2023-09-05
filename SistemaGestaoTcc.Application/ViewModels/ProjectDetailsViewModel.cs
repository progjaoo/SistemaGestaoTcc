using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestaoTcc.Core.Enums;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Application.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public ProjectDetailsViewModel(int id, string nome, string descricao, DateTime? dataInicio, DateTime? dataFim, bool? publicado, bool? aprovado, StatusProjeto estado)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Publicado = publicado;
            Aprovado = aprovado;
            Estado = estado;
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public DateTime? DataInicio { get; set; }

        public DateTime? DataFim { get; set; }

        public bool? Publicado { get; set; }

        public bool? Aprovado { get; set; }

        public StatusProjeto Estado { get; set; }

        public virtual ICollection<UsuarioProjeto> UsuarioProjeto { get; set; } = new List<UsuarioProjeto>();

    }
}
