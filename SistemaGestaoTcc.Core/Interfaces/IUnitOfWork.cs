using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTcc.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IProjectRepository Projects { get; }

        IUserRepository User { get; }
        Task<int> CompleteAsync();
        Task CommitAsync();
    }
}
