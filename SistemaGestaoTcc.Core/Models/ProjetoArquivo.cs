﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SistemaGestaoTcc.Core.Models;

public partial class ProjetoArquivo
{
    public ProjetoArquivo()
    {
    }

    public ProjetoArquivo(int idProjeto, string diretorioArquivo, DateTime? criadoEm)
    {
        IdProjeto = idProjeto;
        DiretorioArquivo = diretorioArquivo;
        CriadoEm = criadoEm;
    }

    public int Id { get; set; } 

    //public int IdUsuario { get; set; }

    public int IdProjeto { get; set; }

    public string DiretorioArquivo { get; set; }

    public DateTime? CriadoEm { get; set; }

    public virtual Projeto IdProjetoNavigation { get; set; }

    //public virtual Usuario IdUsuarioNavigation { get; set; }
}