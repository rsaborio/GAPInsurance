using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Insurace.EF
{
    public class InsuranceContext : DbContext
    {
        public InsuranceContext() 
            : base("DefaultConnection")
        {}
        public DbSet<Client> Client { get; set; }
        public DbSet<Policy> Policy { get; set; }
        public DbSet<CoverageType> CoverageType { get; set; }
    }
}
