using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bnpp.DataLayer.Entities;


namespace Bnpp.DataLayer.Context
{
    public class TransientContext : DbContext
    {
        public TransientContext(DbContextOptions<TransientContext> options) : base(options)
        {
        }


        public DbSet<TransientGroups> TransientGroups { get; set; }
        public DbSet<Transients> Transients { get; set; }
        public DbSet<TransientDocuments> TransientDocuments { get; set; }
        public DbSet<GroupedTransients> GroupedTransients { get; set; }
    }
}
