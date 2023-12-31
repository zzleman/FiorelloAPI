﻿using Fiorello.Domain.Entities;

namespace Fiorello.Application.Abstraction.Repository;
public interface ICategoryReadRepository : IReadRepository<Category>
{
    Task<Category?> GetByIdAysnc(Guid id);
}

