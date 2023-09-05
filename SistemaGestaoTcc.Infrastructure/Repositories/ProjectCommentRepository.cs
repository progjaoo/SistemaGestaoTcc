using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Infrastructure.Repositories
{
    public class ProjectCommentRepository : IProjectCommentRepository
    {
        private readonly SistemaTccContext _dbcontext;

        public ProjectCommentRepository(SistemaTccContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<ProjetoComentario>> GetAllCommentsAsync(string query)
        {
            return await _dbcontext.ProjetoComentario.ToListAsync();
        }



        public async Task<ProjetoComentario> GetCommentById(int id)
        {
            return await _dbcontext.ProjetoComentario.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddCommentAsync(ProjetoComentario projetoComentario)
        {
            await _dbcontext.ProjetoComentario.AddAsync(projetoComentario);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task RemoverAsync(ProjetoComentario projetoComment)
        {
            _dbcontext.Remove(projetoComment);
        }
        public async Task DeleteComment(int id)
        {
            var obj = await _dbcontext.ProjetoComentario.SingleOrDefaultAsync(p => p.Id == id);

            if (obj == null)
                throw new Exception("O comentario nao existe");
            await RemoverAsync(obj);

        }
        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
