using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDSTP.Domain;
using DDSTP.Domain.Entities;

namespace DDSTP.Data
{
    internal static class ShopPOIMap
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShopPOI>()
                .HasMany<Availability>(s => s.Availabilities)
                .WithMany()
                .Map(pr =>
                {
                    pr.MapLeftKey("ShopPOIId");
                    pr.MapRightKey("AvailabilityId");
                    pr.ToTable("ShopPOI_Availability");
                });

        }
    }
}
