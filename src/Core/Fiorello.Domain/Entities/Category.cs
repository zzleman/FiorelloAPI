using System;
using Fiorello.Domain.Entities.Common;

namespace Fiorello.Domain.Entities;

public class Category:BaseEntity
{
    public string? Name { get; set; }

    public string? Description { get; set; }
}

