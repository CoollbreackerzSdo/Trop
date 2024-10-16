namespace Trop.Domain.Common;

public record struct EntityKey<T>(T Value) : IComparable<EntityKey<T>>
    where T : notnull, IComparable<T>
{
    public int CompareTo(EntityKey<T> other)
    {
        throw new NotImplementedException();
    }
    public T Value { get; init; } = Value;
    public static implicit operator EntityKey<T>(T value) => new(value);
    public static implicit operator T(EntityKey<T> entityKey) => entityKey.Value;
}