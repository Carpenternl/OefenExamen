using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TakenlijstManager.Models;

namespace TakenlijstManager.Data
{
    public class StorageContext : DbContext
    {

        public StorageContext (DbContextOptions<StorageContext> options)
            : base(options)
        {
        }


        public DbSet<TaakModel> TakenLijst { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedData.Seed(builder);
        }
        public DbSet<TakenlijstManager.Models.StatusModel> StatusModel { get; set; } = default!;
    }
}
