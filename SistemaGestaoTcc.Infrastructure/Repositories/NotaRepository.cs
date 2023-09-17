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
    public class NotaRepository : INotaRepository
    {
        private readonly SistemaTccContext _dbcontext;

        public NotaRepository(SistemaTccContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<Nota>> GetAllAsync(string query)
        {
            return await _dbcontext.Nota.ToListAsync();
        }

        public async Task<Nota> GetById(int id)
        {
            return await _dbcontext.Nota.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddASync(Nota nota)
        {
            await _dbcontext.AddAsync(nota);
        }

        public async Task RemoverAsync(Nota nota)
        {
            _dbcontext.Remove(nota);
        }
        public async Task DeleteNota(int id)
        {
            var obj = await _dbcontext.Nota.SingleOrDefaultAsync(p => p.Id == id);

            if (obj == null)
                throw new Exception("A nota nao existe");
            await RemoverAsync(obj);
        }

        public async Task SaveChangesAsync()
        {
           await _dbcontext.SaveChangesAsync();
        }
    }
}
