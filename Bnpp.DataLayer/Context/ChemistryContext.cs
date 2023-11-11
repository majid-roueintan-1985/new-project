using Bnpp.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.DataLayer.Context
{
    public class ChemistryContext : DbContext
    {
        public ChemistryContext(DbContextOptions<ChemistryContext> options) : base(options)
        {
        }

        public DbSet<ChemistryTable> ChemistryTable { get; set; }
        public DbSet<ChemistryGroups> ChemistryGroups { get; set; }
    }
}
