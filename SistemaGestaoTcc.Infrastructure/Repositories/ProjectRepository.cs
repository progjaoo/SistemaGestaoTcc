using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //ok
            return await _dbcontext.Projeto.ToListAsync();

        }

        public async Task<Projeto> GetById(int id)
        {
            //ok
            return await _dbcontext.Projeto.SingleOrDefaultAsync(p => p.Id == id);   
        }

        public async Task<Projeto> GetDetailsByIdAsync(int id)
        {
            return await _dbcontext.Projeto
                .Include(p => p.UsuarioProjeto)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddASync(Projeto projeto)
        {
            await _dbcontext.Projeto.AddAsync(projeto);
        }

        public async Task AddCommentAsync(ProjetoComentario projetoComentario)
        {
            await _dbcontext.ProjetoComentario.AddAsync(projetoComentario);

        }
        public Task<Projeto> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Projeto> StartAsync(Projeto projeto)
        {
            throw new NotImplementedException();
        }
    }
}
