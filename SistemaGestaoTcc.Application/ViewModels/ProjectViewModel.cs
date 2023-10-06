using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestaoTcc.Core.Enums;

namespace SistemaGestaoTcc.Application.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel(int id, string nome, string descricao, DateTime? dataInicio, StatusProjeto estado)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            DataInicio = dataInicio;
            Estado = estado;
        }

        public int Id { get; set; } 

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public DateTime? DataInicio { get; set; }

        public StatusProjeto Estado { get; set; }
    }
}
