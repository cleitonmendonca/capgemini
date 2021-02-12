using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Entities;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastruture.Data
{
    public class CapgeminiDbContext : DbContext, ICapgeminiDbContext
    {
        public CapgeminiDbContext(
            DbContextOptions<CapgeminiDbContext> options) : base(options)
        {
            
        }
        public DbSet<Importation> Importations { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedOn = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);

        }
    }
}