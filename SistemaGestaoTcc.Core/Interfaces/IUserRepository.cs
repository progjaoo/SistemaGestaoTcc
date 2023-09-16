using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<List<Usuario>> GetAllUserByCourse(int idCurso);
        Task<List<Usuario>> GetAllUserByRole(string papel);
        Task<Usuario> GetById(int id);
        Task<Usuario> GetByEmailByPassword(string email, string passwordHash);
        Task SaveChangesAsync();
        Task DeleteUser(int id);
    }
}
