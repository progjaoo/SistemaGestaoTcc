using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestaoTcc.Core.Enums;

namespace SistemaGestaoTcc.Application.ViewModels
{
    public class ConviteViewModel
    {
        public ConviteViewModel(int id, DateTime? dataEnvio, DateTime? dataExpira, ConviteAceito aceito)
        {
            Id = id;
            DataEnvio = dataEnvio;
            DataExpira = dataExpira;
            Aceito = aceito;
        }

        public int Id { get; set; }

        public DateTime? DataEnvio { get; set; }

        public DateTime? DataExpira { get; set; }

        public ConviteAceito Aceito { get; set; }
    }
}
