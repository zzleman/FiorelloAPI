using System;
using Fiorello.Application.Abstraction.Repository;
using Fiorello.Domain.Entities;
using Fiorello.Persistance.Contexts;

namespace Fiorello.Persistance.Implementations.Repositories;

public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
{
    public CategoryReadRepository(AppDbContext context) : base(context)
    {
    }

    public Task<Category?> GetByIdAysnc(Guid id)
    {
        throw new NotImplementedException();
    }

    //Guid gore implement aldi yoxla!
}

