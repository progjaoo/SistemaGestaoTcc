﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Core.Interfaces
{
    public interface IProjectRepository
    {
        Task<List<Projeto>> GetAllAsync(string query);
        Task<Projeto> GetById(int id);
        Task<Projeto> GetDetailsByIdAsync (int id);
        Task AddASync(Projeto projeto);
        Task StartAsync(Projeto projeto);
        Task SaveChangesAsync();
    }
}