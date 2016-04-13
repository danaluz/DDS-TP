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
                        
            Database.SetInitializer(new EntitiesContextInitializer());

            //Database.SetInitializer<dbMerchantOnBoard>(new DropCreateDatabaseIfModelChanges<dbMerchantOnBoard>()););

            //Database.SetInitializer<dbMerchantOnBoard>(new CreateDatabaseIfNotExists<dbMerchantOnBoard>());

            //Database.SetInitializer<dbMerchantOnBoard>(new DropCreateDatabaseAlways<dbMerchantOnBoard>());
        }


        public class EntitiesContextInitializer : DropCreateDatabaseIfModelChanges<dbDDSTPContext>
        {
            protected override void Seed(dbDDSTPContext context)
            {
                var street = new Street();
                street.Nombre="Scalabrini Ortiz";
                street.ID = 1;
                context.Streets.Add(street);
                context.SaveChanges();


            }
        }
    }
}
