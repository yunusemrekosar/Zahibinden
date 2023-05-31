using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zahibinden.Data.Entities;
using Zahibinden.Data.Entities.Common;

namespace Zahibinden.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Zahibinden.Data.Entities.Advert>? Adverts { get; set; }
        public DbSet<Zahibinden.Data.Entities.Category>? Categories { get; set; }
        public DbSet<Zahibinden.Data.Entities.User>? Users { get; set; }
        public DbSet<Zahibinden.Data.Entities.City>? Cities { get; set; }
        public DbSet<Zahibinden.Data.Entities.AdvertType>? Types { get; set; }
        public DbSet<Zahibinden.Data.Entities.Image>? Images { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseClass>();

            foreach (var data in datas)
            {
                switch (data.State)
                {
                    case EntityState.Modified:
                        data.Entity.UpdatedOn = DateTime.Now;
                        break;
                    case EntityState.Added:
                        data.Entity.CreatedOn = DateTime.Now;
                        data.Entity.UpdatedOn = DateTime.Now;
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}