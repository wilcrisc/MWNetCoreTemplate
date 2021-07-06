using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ITicketRepositoryAsync Ticket { get; }
        Task<int> Commit();
    }

}
