using Microsoft.EntityFrameworkCore;
using TakenlijstManager.Models;

namespace TakenlijstManager.Data
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaakModel>().HasData(
                new TaakModel(1, "Huiswerk Client", 5, 6),
                new TaakModel(2, "Huiswerk Server", 3, 3),
                new TaakModel(3, "Voorbereiden tentamen Client", 4, 10),
                new TaakModel(4, "Voorbereiden tentamen Server", 5, 10));
        }
    }
}
