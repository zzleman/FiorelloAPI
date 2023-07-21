namespace Fiorello.Domain.Entities.Common;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public virtual bool IsDeleted { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
}

