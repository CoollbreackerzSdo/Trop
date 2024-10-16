namespace Trop.Domain.Common;

public interface IEntity<T>
{
    T Key { get; }
}