using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTcc.Application.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel(int id, string nome, DateTime? dataInicio)
        {
            Id = id;
            Nome = nome;
            DataInicio = dataInicio;
        }

        public int Id { get; set; } 

        public string Nome { get; set; }

        public DateTime? DataInicio { get; set; }
    }
}
