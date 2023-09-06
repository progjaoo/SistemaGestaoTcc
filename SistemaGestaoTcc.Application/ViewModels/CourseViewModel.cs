using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaGestaoTcc.Application.ViewModels
{
    public class CourseViewModel
    {
        public CourseViewModel(int id, string nome, int? periodos)
        {
            Id = id;
            Nome = nome;
            Periodos = periodos;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int? Periodos { get; set; }
    }
}