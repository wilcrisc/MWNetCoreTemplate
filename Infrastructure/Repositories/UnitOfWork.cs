using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Respositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private bool disposed;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            Ticket = new TicketRepositoryAsync(_dbContext);
            
        }

        public ITicketRepositoryAsync Ticket { get; private set; }

        public async Task<int> Commit()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            disposed = true;
        }
    }
}
