using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Core.Interfaces
{
    public interface INotaRepository
    {
        Task<List<Nota>> GetAllAsync(string query);
        Task<Nota> GetById(int id);
        Task AddASync(Nota nota);
        Task DeleteNota(int id);
        Task SaveChangesAsync();
    }
}
