﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SistemaGestaoTcc.Core.Models;

public partial class Nota
{
    public int Id { get; set; }

    public int IdProjeto { get; set; }

    public int IdUsuario { get; set; }

    public int? Valor { get; set; }

    public virtual Projeto IdProjetoNavigation { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; }
}