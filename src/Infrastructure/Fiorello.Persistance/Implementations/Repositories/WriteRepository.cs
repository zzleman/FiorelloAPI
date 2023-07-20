using System;
using Fiorello.Application.Abstraction.Repository;
using Fiorello.Domain.Entities.Common;
using Fiorello.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Persistance.Implementations.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity, new()
{
    private readonly AppDbContext _context;

    public DbSet<T> Table => _context.Set<T>();

    public WriteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(T entity) => await Table.AddAsync(entity);

    public async Task AddRangeAsync(ICollection<T> entites) => await Table.AddRangeAsync(entites);

    public void Remove(T entity) => Table.Remove(entity);

    public void RemoveRange(ICollection<T> entites) => Table.RemoveRange(entites);

    public async Task SaveChangeAsync() => await _context.SaveChangesAsync();

    public void Update(T entity)
    {
        Table.Update(entity);
    }
}

