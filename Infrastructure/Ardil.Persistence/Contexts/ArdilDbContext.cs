using Ardil.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ardil.Persistence.Contexts
{
    public class ArdilDbContext : BaseDbContext
    {
        public ArdilDbContext(DbContextOptions options) : base(options)
        {
            
        }


        public DbSet<Entry> Entries { get; set; }
        public DbSet<Topic> Topics { get; set; }
    }
}
