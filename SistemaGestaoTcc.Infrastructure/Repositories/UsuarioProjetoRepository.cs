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
    public class UsuarioProjetoRepository : IUsuarioProjetoRepository
    {
        private readonly SistemaTccContext _dbcontext;

        public UsuarioProjetoRepository(SistemaTccContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddASync(UsuarioProjeto usuarioProjeto)
        {
            await _dbcontext.UsuarioProjeto.AddAsync(usuarioProjeto);
        }
        public async Task<List<UsuarioProjeto>> GetAllAsync()
        {
            return await _dbcontext.UsuarioProjeto.ToListAsync();
        }

        public async Task<List<UsuarioProjeto>> GetAllByUserId(int id)
        {
            return await _dbcontext.UsuarioProjeto.Where(up => up.IdUsuario == id).ToListAsync();
        }

        public async Task<List<UsuarioProjeto>> GetAllByProjectId(int id)
        {
            return await _dbcontext.UsuarioProjeto.Where(up => up.IdProjeto == id).ToListAsync();
        }

        public async Task<UsuarioProjeto> GetById(int id)
        {
            return await _dbcontext.UsuarioProjeto.SingleOrDefaultAsync(up => up.Id == id);
            
        }

        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
        public async Task RemoverAsync(UsuarioProjeto usuarioProjeto)
        {
            _dbcontext.Remove(usuarioProjeto);
        }
        public async Task DeleteUserProj(int id)
        {
            var obj = await _dbcontext.UsuarioProjeto.SingleOrDefaultAsync(p => p.Id == id);

            if (obj == null)
                throw new Exception("O usuario do Projeto nao existe");
            await RemoverAsync(obj);

        }
    }
}
