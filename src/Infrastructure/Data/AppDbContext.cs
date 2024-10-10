using Domain.Base;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data.Core;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext : DbContext
{
    public string CurrentUser;
    public AppDbContext(DbContextOptions<AppDbContext> options, IUserResolverService currentUser) : base(options)
    {
        CurrentUser = currentUser.GetUser() ?? "Anonymous";
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Initiative>()
            .Property(_ => _.Id)
            // Set sequential Uuid generation.
            .HasValueGenerator<SequentialUuidGenerator>();

        modelBuilder
            .Entity<Initiative>()
            .HasIndex(_ => _.Id);
    }

    /// <summary>
    /// Set specific properties before saving : CreatedDate, CreatedBy, InstanceLabel, ...
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>Result of base.SaveChangesAsync</returns>
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var AddedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Added).ToList();

        AddedEntities.ForEach(E =>
        {
            ((BaseEntity)E.Entity).CreatedDate = DateTime.Now;
            ((BaseEntity)E.Entity).CreatedBy = CurrentUser;
            ((BaseEntity)E.Entity).InstanceLabel = ((BaseEntity)E.Entity).GenerateInstanceLabel();
        });

        var EditedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Modified).ToList();

        EditedEntities.ForEach(E =>
        {
            ((BaseEntity)E.Entity).UpdatedDate = DateTime.Now;
            ((BaseEntity)E.Entity).UpdatedBy = CurrentUser;
            ((BaseEntity)E.Entity).InstanceLabel = ((BaseEntity)E.Entity).GenerateInstanceLabel();
        });

        return base.SaveChangesAsync(cancellationToken);
    }
}