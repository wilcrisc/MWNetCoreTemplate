using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Infrastructure.Data
{
    public class ServicePortalDbContext : IdentityDbContext
    {
        public ServicePortalDbContext(DbContextOptions<ServicePortalDbContext> options)
            : base(options)
        {
        }

        public DbSet<Core.Entities.Ticket> Tickets { get; set; }
    }
}
