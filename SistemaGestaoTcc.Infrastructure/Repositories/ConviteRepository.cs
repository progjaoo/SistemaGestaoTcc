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

    public class ConviteRepository : IConviteRepository
    {
        private readonly SistemaTccContext _dbcontext;

        public ConviteRepository(SistemaTccContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddASync(Convite convite)
        {
            await _dbcontext.Convite.AddAsync(convite);
        }

        public async Task<List<Convite>> GetAllAsync(string query)
        {
            return await _dbcontext.Convite.ToListAsync();
        }

        public async Task<List<Convite>> GetAllByUserId(int id)
        {
            return await _dbcontext.Convite
            .Where(up => up.IdUsuario == id)
            .Where(up => up.Aceito == Core.Enums.ConviteAceito.Pendente)
            .Include(up => up.IdProjetoNavigation)
            .ToListAsync();
        }

        public async Task<List<Convite>> GetAllByProjectId(int id)
        {
            return await _dbcontext.Convite
            .Where(up => up.IdProjeto == id)
            .Where(up => up.Aceito == Core.Enums.ConviteAceito.Pendente)
            .Include(up => up.IdProjetoNavigation)
            .ToListAsync();
        }

        public async Task<Convite> GetById(int id)
        {
            return await _dbcontext.Convite.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
        public async Task RemoverAsync(Convite convite)
        {
            _dbcontext.Remove(convite);
        }
        public async Task DeleteConvite(int id)
        {
            var obj = await _dbcontext.Convite.SingleOrDefaultAsync(p => p.Id == id);

            if (obj == null)
                throw new Exception("O Convite nao existe");
            await RemoverAsync(obj);

        }
    }
}
