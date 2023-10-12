using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTcc.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(int id, string nome, string email, int idCurso, string papel, string? imagem)
        {
            Id = id;
            Nome = nome;
            Email = email;
            IdCurso = idCurso;
            Papel = papel;
            Imagem = imagem;
        }
        public UserViewModel(string nome, string email, int idCurso)
        {
            Nome = nome;
            Email = email;
            IdCurso = idCurso;
        }
        public UserViewModel(int id, string nome, string email, int idCurso, string papel)
        {
            Id = id;
            Nome = nome;
            Email = email;
            IdCurso = idCurso;
            Papel = papel;
        }
        public int? Id { get; set; }
        public string? Imagem { get; set; }
        public string? Nome { get; set; }
        public string Email { get; set; }
        public int IdCurso { get; set; }
        public string? Papel { get; set; }

    }
}
