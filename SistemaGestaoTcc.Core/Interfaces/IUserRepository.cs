using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<List<Usuario>> GetAllUserByCourse(int idCurso);
        Task<List<Usuario>> GetAllUserByRole(string papel);
        Task<Usuario> GetById(int id);
        Task<Usuario> GetByEmailByPassword(string email, string passwordHash);
        Task<Usuario> GetByEmail(string email);
        Task SaveChangesAsync();
        Task DeleteUser(int id);
    }
}
