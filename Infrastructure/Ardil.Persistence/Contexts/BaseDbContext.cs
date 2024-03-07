using Ardil.Domain.Entities.Common;
using Ardil.Domain.Entities.Identity;
using Ardil.Persistence.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ardil.Persistence.Contexts
{
    public class BaseDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public BaseDbContext(DbContextOptions options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Seed();
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            AddedEntries();
            ModifiedEntries();
            return base.SaveChanges();
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddedEntries();
            ModifiedEntries();
            return base.SaveChangesAsync(cancellationToken);
        }

        public  void AddedEntries()
        {
            var insertedEntries = ChangeTracker
              .Entries()
              .Where(x => x.State == EntityState.Added)
              .Select(x => x.Entity);

            foreach (var insertedEntry in insertedEntries)
            {
                var baseEntity = insertedEntry as BaseEntity;

                if (baseEntity is not null)
                {
                    baseEntity.Id = Guid.NewGuid();
                    baseEntity.CreatedDate = DateTime.UtcNow;
                }
            }
        }

        public void ModifiedEntries()
        {
            var modifiedEntries = ChangeTracker
                .Entries()
                .Where(x => x.State == EntityState.Modified)
                .Select(x => x.Entity);

            foreach (var modifiedEntry in modifiedEntries)
            {
                var baseEntity = modifiedEntry as BaseEntity;

                if (baseEntity is not null)
                {
                    baseEntity.UpdatedDate = DateTime.UtcNow;
                }
            }
        }
    }
}
