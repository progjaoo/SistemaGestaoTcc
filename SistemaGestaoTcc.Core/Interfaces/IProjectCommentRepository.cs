using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Core.Interfaces
{
    public interface IProjectCommentRepository
    {
        Task<List<ProjetoComentario>> GetAllCommentsByProjectAsync(int query);
        Task<ProjetoComentario> GetCommentById(int id);
        Task DeleteComment(int id);
        Task AddCommentAsync(ProjetoComentario projetoComentario);
        Task SaveChangesAsync();
    }
}
