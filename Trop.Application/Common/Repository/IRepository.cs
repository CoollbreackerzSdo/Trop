using System.Linq.Expressions;

using Trop.Domain.Common;
using Trop.Domain.Models.User;

namespace Trop.Application.Common.Repository;

public interface IRepository<T>
    where T : EntityBase
{
    TResult WithAddMap<TResult>(T model, Func<T, TResult> map);
    void Add(T model);
    T Find<TKey>(TKey keyFilter);
    T? FindAsDefault<TKey>(TKey keyFilter);
    T WithFindMap<TResult, TKey>(TKey keyFilter, Func<T, TResult> map);
    T? WithFindMapAsDefault<TResult, TKey>(TKey keyFilter, Func<T, TResult> map);
    T Single(Expression<Func<T, bool>> expressionFilter);
    T? SingleAsDefault(Expression<Func<T, bool>> expressionFilter);
    T WithSingleMap<TResult>(Expression<Func<T, bool>> expressionFilter, Func<T, TResult> map);
    T? WithSingleMapAsDefault<TResult>(Expression<Func<T, bool>> expressionFilter, Func<T, TResult> map);
}
public interface IUserRepository : IRepository<UserEntity> { }
public interface IUnitOfWord : IDisposable
{
    IUserRepository Repository { get; }
    Task SaveChangesAsync(CancellationToken token);
}