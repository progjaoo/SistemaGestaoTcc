using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestaoTcc.Core.Enums;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Application.ViewModels
{
    public class ConviteViewModel
    {
        public ConviteViewModel(int id, int idProjeto, int idUsuario, Projeto projeto, DateTime? dataEnvio, DateTime? dataExpira, ConviteAceito aceito)
        {
            Id = id;
            IdProjeto = idProjeto;
            IdUsuario = idUsuario;
            this.projeto = projeto;
            DataEnvio = dataEnvio;
            DataExpira = dataExpira;
            Aceito = aceito;
        }

        public int Id { get; set; }
        public int IdProjeto { get; set; }
        public int IdUsuario { get; set; }

        public Projeto projeto { get; set; }

        public DateTime? DataEnvio { get; set; }

        public DateTime? DataExpira { get; set; }

        public ConviteAceito Aceito { get; set; }
    }
}
