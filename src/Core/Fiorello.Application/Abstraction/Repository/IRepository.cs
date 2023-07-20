using Fiorello.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Fiorello.Application.Abstraction.Repository;

public interface IRepository<T> where T : BaseEntity, new()
{
    public DbSet<T> Table { get; }
}

