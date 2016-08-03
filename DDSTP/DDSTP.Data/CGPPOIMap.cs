using System.Data.Entity;
using DDSTP.Domain;

namespace DDSTP.Data
{
    internal static class CGPPOIMap
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CGPPOI>()
                .HasMany<KeyWord>(s => s.KeyWords)
                .WithMany()
                .Map(pr =>
                {
                    pr.MapLeftKey("CGPPOIId");
                    pr.MapRightKey("KeyWordId");
                    pr.ToTable("CGPPOI_KeyWord");
                });
        }
    }
}
