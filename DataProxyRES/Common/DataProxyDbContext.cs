using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Common
{
    public class DataProxyDbContext : DbContext
    {
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Region> Regions { get; set; }
    }
}
