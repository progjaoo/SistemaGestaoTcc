using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTcc.Application.ViewModels
{
    public class UserRoleViewModel
    {
        public UserRoleViewModel(string nome, string email, string papel, int idCurso)
        {
            Nome = nome;
            Email = email;
            Papel = papel;
            IdCurso = idCurso;
        }

        public string Nome { get; set; }

        public string Email { get; set; }
        
        public string Papel { get; set; }

        public int IdCurso { get; set; }
    }
}
