﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SistemaGestaoTcc.Core.Models;

public partial class Curso
{

    public int Id { get; set; }
    public string Nome { get; set; }

    public int? Periodos { get; set; }

    public virtual ICollection<Banca> Banca { get; set; } = new List<Banca>();

    public virtual ICollection<Calendario> Calendario { get; set; } = new List<Calendario>();
}