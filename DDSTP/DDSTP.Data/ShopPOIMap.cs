using System.Data.Entity;
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

            modelBuilder.Entity<ShopPOI>()
                .HasMany<KeyWord>(s => s.KeyWords)
                .WithMany()
                .Map(pr =>
                {
                    pr.MapLeftKey("ShopPOIId");
                    pr.MapRightKey("KeyWordId");
                    pr.ToTable("ShopPOI_KeyWord");
                });
        }
    }
}
