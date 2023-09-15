using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTcc.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string nome, string email, int idCurso)
        {
            Nome = nome;
            Email = email;
            IdCurso = idCurso;
        }

        public string Nome { get; set; }

        public string Email { get; set; }

        public int IdCurso { get; set; }
    }
}
