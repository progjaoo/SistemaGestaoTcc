﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly SistemaTccContext _dbcontext;
        private readonly string _connectionString;

        public ProjectRepository(SistemaTccContext dbcontext, IConfiguration configuration)
        {
            _dbcontext = dbcontext;
            _connectionString = configuration.GetConnectionString("SistemaTcc");
        }

        public async Task<List<Projeto>> GetAllAsync(string query)
        {
            return await _dbcontext.Projeto.ToListAsync();

        }

        public async Task<Projeto> GetById(int id)
        {
            return await _dbcontext.Projeto.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Projeto> GetDetailsByIdAsync(int id)
        {
            return await _dbcontext.Projeto.SingleOrDefaultAsync(p => p.Id == id);
        }
        public async Task AddASync(Projeto projeto)
        {
            await _dbcontext.Projeto.AddAsync(projeto);
        }

        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
        public async Task StartAsync(Projeto projeto)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "UPDATE Projects SET Estado = @estado, DataInicio = @datainicio WHERE Id = @id";

                await sqlConnection.ExecuteAsync(script, new { estado = projeto.Estado, datainicio = projeto.DataInicio, projeto.Id });
            }
        }
        public async Task TornarPublico(int id)
        {
            var projeto = await _dbcontext.Projeto.FindAsync(id);

            if (projeto != null)
            {
                projeto.Publicado = !projeto.Publicado;

                await _dbcontext.SaveChangesAsync();
            }
        }
    }
}
