using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TDADomain.DataAccess.RepoPatterns
{
    public interface IUnitOfWork
    {
        Task<bool> Complete();
        void Dispose();
    }
}
