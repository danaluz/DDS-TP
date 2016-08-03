using System.Data.Entity;
using DDSTP.Domain;
using DDSTP.Domain.Entities;

namespace DDSTP.Data
{
    internal static class BankPOIMap
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankPOI>()
                .HasMany<KeyWord>(s => s.KeyWords)
                .WithMany()
                .Map(pr =>
                {
                    pr.MapLeftKey("BankPOIId");
                    pr.MapRightKey("KeyWordId");
                    pr.ToTable("BankPOI_KeyWord");
                });
        }
    }
}
