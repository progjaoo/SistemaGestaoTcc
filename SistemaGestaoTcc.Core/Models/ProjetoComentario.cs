﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SistemaGestaoTcc.Core.Models;

public partial class ProjetoComentario : BaseEntity
{
    public ProjetoComentario(int idUsuario, int idProjeto, string conteudo)
    {
        IdUsuario = idUsuario;
        IdProjeto = idProjeto;
        Conteudo = conteudo;
        CriadoEm = DateTime.Now;
    }

    public int IdUsuario { get; set; }

    public int IdProjeto { get; set; }

    public string Conteudo { get; set; }

    public DateTime? CriadoEm { get; set; }

    public bool? Editado { get; set; }

    public bool? Avaliacao { get; set; }

    public virtual Projeto IdProjetoNavigation { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; }



    public void UpdateComment(string conteudo)
    {
        Conteudo = conteudo;
    }
}