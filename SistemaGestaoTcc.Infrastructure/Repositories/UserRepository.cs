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
    public class UserRepository : IUserRepository
    {
        private readonly SistemaTccContext _dbcontext;

        public UserRepository(SistemaTccContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Usuario> GetById (int id)
        {
            return await _dbcontext.Usuario.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Usuario> GetByEmailByPassword(string email, string passwordHash)
        {
            return await _dbcontext.Usuario.SingleOrDefaultAsync(u => u.Email == email && u.Senha == passwordHash);
        }
    }
}
