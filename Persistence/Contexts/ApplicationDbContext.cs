﻿using Application.Interfaces;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts;

public class ApplicationDbContext:DbContext
{
    private readonly IDateTimeService _dateTime;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTime):base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        _dateTime = dateTime;
    }
    public DbSet<Client> Clients { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.Created = _dateTime.NowUTC;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModified = _dateTime.NowUTC;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}