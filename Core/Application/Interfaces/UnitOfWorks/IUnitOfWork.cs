using Application.Interfaces.Repositories;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IReadRepo <T>   GetReadRepo <T>() where T : class, IEntityBase, new();
        IWriteRepo<T>   GetWriteRepo<T>() where T : class, IEntityBase, new();
        Task      <int> SaveAsync();
        int             Save();
    }
}
