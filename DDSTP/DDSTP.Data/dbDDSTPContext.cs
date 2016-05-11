using DDSTP.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDSTP.APIService;
using DDSTP.Domain.Components;
using DDSTP.Domain.Entities;

namespace DDSTP.Data
{
    public class dbDDSTPContext : DbContext
    {
        public virtual DbSet<POI> POIs { get; set; }
        public virtual DbSet<Availability> Availabilities { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Street> Streets { get; set; }
        public virtual DbSet<Community> Communities { get; set; }

        public dbDDSTPContext()
            : base("dbDDSTPContext")
        {

            Database.SetInitializer(new EntitiesContextInitializer());

            //Database.SetInitializer<dbMerchantOnBoard>(new DropCreateDatabaseIfModelChanges<dbMerchantOnBoard>()););

            //Database.SetInitializer<dbMerchantOnBoard>(new CreateDatabaseIfNotExists<dbMerchantOnBoard>());

            //Database.SetInitializer<dbMerchantOnBoard>(new DropCreateDatabaseAlways<dbMerchantOnBoard>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShopPOI>().ToTable("ShopPOIs");
            modelBuilder.Entity<BankPOI>().ToTable("BankPOIs");
            modelBuilder.Entity<BusStopPOI>().ToTable("BusStopPOIs");
            modelBuilder.Entity<CGPPOI>().ToTable("CGPPOI");
        }

        public class EntitiesContextInitializer : DropCreateDatabaseIfModelChanges<dbDDSTPContext>
        {
            protected override void Seed(dbDDSTPContext context)
            {
                var street = new Street();
                street.Nombre = "Scalabrini Ortiz";
                street.ID = 1;
                context.Streets.Add(street);
                context.SaveChanges();

                var av1 = new Availability();
                av1.OpenTime = new TimeSpan(0, 0, 0);
                av1.CloseTime = new TimeSpan(7, 0, 0);
                av1.Day = DayOfWeek.Thursday;

                var av2 = new Availability();
                av2.OpenTime = new TimeSpan(10, 0, 0);
                av2.CloseTime = new TimeSpan(15, 0, 0);
                av2.Day= DayOfWeek.Monday;

                var bank1 = new BankPOI();
                bank1.Geolocation = GeoHelper.PointFromLatLng(-34.581828f, -58.412723f);
                bank1.MainStreet = street;
                bank1.Number = 3669;
                bank1.Name = "Banco Santander Río";
                context.POIs.Add(bank1);
                context.SaveChanges();


                var serviceAPI = new CommunityService();
                var communities = serviceAPI.GetAllCommunities();
                foreach (var c in communities)
                {
                    var dbcommunity = new Community();

                    var polygonLimits = c.GeoJson.GetPolygonLimits()
                                        .Select(x => new DDSTP.Domain.Components.Point()
                                        {
                                            Longitude = x.Longitude,
                                            Latitude = x.Latitude
                                        }).ToList();

                    dbcommunity.Polygon = GeoHelper.PolygonFromLatLng(polygonLimits);
                    dbcommunity.CommunityNumber = c.CommunityNumber;
                    context.Communities.Add(dbcommunity);
                    context.SaveChanges();
                }

            }
        }
    }
}
