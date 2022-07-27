using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class StationContext : DbContext
    {
        public StationContext(DbContextOptions options) : base(options) { }

        public DbSet<Station> Station { get; set; }
        public DbSet<Measurement> Measurement { get; set; }
    }
}
