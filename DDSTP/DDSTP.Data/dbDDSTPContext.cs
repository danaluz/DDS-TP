using DDSTP.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDSTP.Data
{
    public class dbDDSTPContext : DbContext 
    {
        public DbSet<POI> POIs { get; set; }
        public DbSet<Street> Streets { get; set; }

        public dbDDSTPContext()
            : base("dbDDSTPContext")
        {
            Database.SetInitializer<dbDDSTPContext>(new DropCreateDatabaseIfModelChanges<dbDDSTPContext>());
        }
    }
}
