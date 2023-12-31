﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using SistemaGestaoTcc.Core.Enums;

namespace SistemaGestaoTcc.Core.Models;

public partial class Convite : BaseEntity
{

    public int IdUsuario { get; set; }

    public int IdProjeto { get; set; }

    public DateTime? DataEnvio { get; set; }

    public DateTime? DataExpira { get; set; }

    public ConviteAceito Aceito { get; set; }

    public virtual Projeto IdProjetoNavigation { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; }

    public void Update(ConviteAceito aceito)
    {
        Aceito = aceito;
    }
}