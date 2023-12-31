﻿using System;
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

        public async Task<List<Usuario>>GetAllUserByCourse(int idCurso)
        {

            return await _dbcontext.Usuario.Where(c => c.IdCurso == idCurso).ToListAsync();
        }

        public async Task<List<Usuario>> FilterUsers(string papel, string nome)
        {
            return await _dbcontext.Usuario.Where(u => u.Papel == papel).Where(u => u.Nome.Contains(nome)).Take(5).ToListAsync();
        }

        public async Task<List<Usuario>> GetAllUserByRole(string papel)
        {
            return await _dbcontext.Usuario.Where(u => u.Papel == papel).ToListAsync();
        }
        
        public async Task<Usuario> GetById (int id)
        {
            return await _dbcontext.Usuario.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Usuario> GetByEmailByPassword(string email, string passwordHash)
        {
            return await _dbcontext.Usuario.SingleOrDefaultAsync(u => u.Email == email && u.Senha == passwordHash);
        }
        public async Task<Usuario> GetByEmail(string email)
        {
            return await _dbcontext.Usuario.SingleOrDefaultAsync(u => u.Email == email);
        }
        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();

        }
        //DELETE 
        public async Task RemoverAsync(Usuario usuario)
        {
            _dbcontext.Remove(usuario);
        }
        public async Task DeleteUser(int id)
        {
            var obj = await _dbcontext.Usuario.SingleOrDefaultAsync(p => p.Id == id);

            if (obj == null)
                throw new Exception("O Usuario nao existe");
            await RemoverAsync(obj);

        }
    }
}
