using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Respositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TicketRepositoryAsync : GenericRepositoryAsync<Ticket>, ITicketRepositoryAsync
    {
        private readonly DbSet<Ticket> _db;

        public TicketRepositoryAsync(AppDbContext dbContext) : base(dbContext)
        {
            _db = dbContext.Set<Ticket>();
        }
    }
}
