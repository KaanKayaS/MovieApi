using MovieApi.Application.Interfaces.Repositories;
using MovieApi.Application.Interfaces.UnitOfWorks;
using MovieApi.Persistence.Context;
using MovieApi.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public ValueTask DisposeAsync()
        {
            return appDbContext.DisposeAsync();
        }

        public IReadRepository<T> GetReadRepository<T>() where T : class, new()
        {
            return new ReadRepository<T>(appDbContext);
        }

        public IWriteRepository<T> GetWriteRepository<T>() where T : class, new()
        {
            return new WriteRepository<T>(appDbContext);
        }

        public int Save()
        {
            return appDbContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await appDbContext.SaveChangesAsync();
        }
    }
}
