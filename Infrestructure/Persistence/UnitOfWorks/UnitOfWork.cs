using Application.Interfaces.Repositories;
using Application.Interfaces.UnitOfWorks;
using Persistence.Context;
using Persistence.Rpositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext dbContext;
        public UnitOfWork(AppDBContext dBContext)
        {
            this.dbContext = dBContext;
        }

        public async ValueTask DisposeAsync() => await dbContext.DisposeAsync();
        public int Save() => dbContext.SaveChanges();
        public async Task<int> SaveAsync() => await dbContext.SaveChangesAsync();
        IReadRepo<T> IUnitOfWork.GetReadRepo<T>() => new ReadRepository<T>(dbContext);
        IWriteRepo<T> IUnitOfWork.GetWriteRepo<T>() => new WriteRepository<T>(dbContext);
    }
}
