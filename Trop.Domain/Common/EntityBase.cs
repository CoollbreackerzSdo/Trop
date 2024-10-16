namespace Trop.Domain.Common;

public class EntityBase : IEntity<EntityKey<Guid>>
{
    public EntityKey<Guid> Key { get; init; } = Guid.CreateVersion7();
}