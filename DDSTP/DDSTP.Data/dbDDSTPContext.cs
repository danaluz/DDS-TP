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
        public virtual DbSet<BankServiceAvailability> BankServiceAvailabilities { get; set; }
        public virtual DbSet<CGPServiceAvailability> CgpServiceAvailabilities { get; set; }
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
            ShopPOIMap.Map(modelBuilder);
        }

        public class EntitiesContextInitializer : DropCreateDatabaseIfModelChanges<dbDDSTPContext>
        {
            protected override void Seed(dbDDSTPContext context)
            {
                //Una calle, para ser utilizada en otro POI
                var street = new Street();
                street.Nombre = "Scalabrini Ortiz";
                street.ID = 1;
                context.Streets.Add(street);
                context.SaveChanges();

                //Disponibilidad de horarios para banco Santander
                var bk1 = new Availability();
                bk1.OpenTime = new TimeSpan(10, 0, 0);
                bk1.CloseTime = new TimeSpan(23, 59, 59);
                bk1.Day = DayOfWeek.Monday;
                var bk2 = new Availability();
                bk2.OpenTime = new TimeSpan(0, 0, 0);
                bk2.CloseTime = new TimeSpan(23, 59, 59);
                bk2.Day = DayOfWeek.Tuesday;
                var bk3 = new Availability();
                bk3.OpenTime = new TimeSpan(10, 0, 0);
                bk3.CloseTime = new TimeSpan(15, 0, 0);
                bk3.Day = DayOfWeek.Wednesday;
                var bk4 = new Availability();
                bk4.OpenTime = new TimeSpan(10, 0, 0);
                bk4.CloseTime = new TimeSpan(15, 0, 0);
                bk4.Day = DayOfWeek.Thursday;
                var bk5 = new Availability();
                bk5.OpenTime = new TimeSpan(10, 0, 0);
                bk5.CloseTime = new TimeSpan(15, 0, 0);
                bk5.Day = DayOfWeek.Friday;

                var service1 = new Service();
                service1.ServiceName = "depositos";

                //Un Banco, con localización, calle, numero y Nombre
                var bank1 = new BankPOI();
                bank1.Geolocation = GeoHelper.PointFromLatLng(-34.581828f, -58.412723f);
                bank1.MainStreet = street;
                bank1.Number = 3669;
                bank1.Name = "Banco Santander Río";
                bank1.BankServiceAvaibilities.Add(new BankServiceAvailability()
                {
                    BankPoi = bank1,
                    Availability = bk1,
                    Service = service1,
                });
                bank1.BankServiceAvaibilities.Add(new BankServiceAvailability()
                {
                    BankPoi = bank1,
                    Availability = bk2,
                    Service = service1,
                });
                context.POIs.Add(bank1);
                context.SaveChanges();


                //Cargado de comunidades a partir de dataset del gobierno
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

                //Una disponibilidad, all day para el dia martes
                var av1 = new Availability();
                av1.OpenTime = new TimeSpan(0, 0, 0);
                av1.CloseTime = new TimeSpan(23, 59, 59);
                av1.Day = DayOfWeek.Tuesday;
                
                //Un Servicio, para ser utilizado por un CGP
                var serviceCGP = new Service();
                serviceCGP.ServiceName = "asesoramiento legal";

                //Un CGP, con un servicio y una comunidad (la 2)
                var poi1 = new CGPPOI();
                poi1.CGPServiceAvailabilities.Add( new CGPServiceAvailability()
                {
                    CGPPoi = poi1,
                    Availability = av1,
                    Service = serviceCGP
                });
                poi1.Community = context.Communities.First();
                poi1.Name = "CGP 2";
                context.POIs.Add(poi1);
                context.SaveChanges();

                //Una categoría, de tipo Librería con una distancia para considerar la Cercanía
                var rubro = new Category();
                rubro.DistanceLess = 800;
                rubro.Name = "librería";

                //Una disponibilidad, de las 12 de la noche a las 7 de la mañana los días Jueves
                var av2 = new Availability();
                av2.OpenTime = new TimeSpan(0, 0, 0);
                av2.CloseTime = new TimeSpan(24, 0, 0);
                av2.Day = DayOfWeek.Tuesday;


                //Un Comercio, con una disponbilidad y un rubro
                var shop1 = new ShopPOI();
                shop1.Name = "Librería Pepito";
                shop1.Geolocation = GeoHelper.PointFromLatLng(-34.581828f, -58.412723f);
                shop1.Category = rubro;
                shop1.Availabilities.Add(av1);
                context.POIs.Add(shop1);
                context.SaveChanges();

                //Una Parada de Colectivo
                var busstop1 = new BusStopPOI();
                busstop1.Name = "114";
                busstop1.Geolocation = GeoHelper.PointFromLatLng(-34.593438f, -58.413051f);
                context.POIs.Add(busstop1);
                context.SaveChanges();

            }
        }
    }
}
