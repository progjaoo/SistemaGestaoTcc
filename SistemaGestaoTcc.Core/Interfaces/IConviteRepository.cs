using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Core.Interfaces
{
    public interface IConviteRepository
    {
        Task<Convite> GetById(int id);
        Task<List<Convite>> GetAllAsync(string query);
        Task<List<Convite>> GetAllByUserId(int id);
        Task<List<Convite>> GetAllByProjectId(int id);
        Task AddASync(Convite convite);
        Task SaveChangesAsync();
        Task DeleteConvite(int id);
    }
}
