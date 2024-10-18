using System.Linq.Expressions;

using Trop.Domain.Common;
using Trop.Domain.Models.User;

namespace Trop.Application.Common.Repository;

public interface IRepository<T>
    where T : EntityBase
{
    IQueryable<T> GetAll();
    TResult WithAddMap<TResult>(T model, Func<T, TResult> map);
    void Add(T model);
    T? FindAsDefault<TKey>(TKey keyFilter);
    TResult? WithFindMapAsDefault<TResult, TKey>(TKey keyFilter, Func<T?, TResult?> map);
    T? SingleAsDefault(Expression<Func<T, bool>> expressionFilter);
    TResult? WithSingleMapAsDefault<TResult>(Expression<Func<T, bool>> expressionFilter, Func<T?, TResult?> map);
    bool Any(Expression<Func<T, bool>> expression);
}
public interface IUserRepository : IRepository<UserEntity> { }
public interface IUnitOfWord : IDisposable
{
    IUserRepository UserRepository { get; }
    Task SaveChangesAsync(CancellationToken token);
}