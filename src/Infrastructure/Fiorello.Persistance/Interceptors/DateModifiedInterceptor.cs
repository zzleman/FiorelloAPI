using System;
using Fiorello.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Fiorello.Persistance.Interceptors;

public class DateModifiedInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)

    {
        UpdateDateProperities(eventData.Context.ChangeTracker.Entries());
            return base.SavingChangesAsync(
                 eventData,
                 result,
                 cancellationToken);
    }

    private static void UpdateDateProperities(IEnumerable<EntityEntry> entityEntries)
    {
        var timeNow = DateTime.Now;

        foreach (var entry in entityEntries)
        {
            if (entry.State == EntityState.Added && entry.Entity is BaseEntity)
            {
                var entity = (BaseEntity)entry.Entity;
                entity.DateCreated = timeNow;
                entity.DateModified = timeNow;
            }
            else if (entry.State == EntityState.Modified && entry.Entity is BaseEntity)
            {
                var entity = (BaseEntity)entry.Entity;
                entity.DateModified = timeNow;
            }
        }

    }
}

