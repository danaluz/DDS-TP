using System.Data.Entity;
using DDSTP.Domain;
using DDSTP.Domain.Entities;

namespace DDSTP.Data
{
    internal static class BusStopPOIMap
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusStopPOI>()
                .HasMany<KeyWord>(s => s.KeyWords)
                .WithMany()
                .Map(pr =>
                {
                    pr.MapLeftKey("BusStopPOIId");
                    pr.MapRightKey("KeyWordId");
                    pr.ToTable("BusStopPOI_KeyWord");
                });
        }
    }
}
