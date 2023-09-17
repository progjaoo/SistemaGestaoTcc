using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTcc.Application.ViewModels
{
    public class NotaViewModel
    {
        public NotaViewModel(int idProjeto, int idUsuario, int? valor)
        {
            IdProjeto = idProjeto;
            IdUsuario = idUsuario;
            Valor = valor;
        }

        public int IdProjeto { get; set; }

        public int IdUsuario { get; set; }

        public int? Valor { get; set; }
    }
}
