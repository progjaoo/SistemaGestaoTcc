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
    public class CourseRepository : ICourseRepository
    {
        private readonly SistemaTccContext _dbcontext;

        public CourseRepository(SistemaTccContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<Curso>> GetAllAsync(string query)
        {
            return await _dbcontext.Curso.ToListAsync();
        }

        public async Task<Curso> GetById(int id)
        {
            return await _dbcontext.Curso.SingleOrDefaultAsync(p => p.Id == id);
        }
        public async Task AddASync(Curso curso)
        {
            await _dbcontext.Curso.AddAsync(curso);
        }

        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
