using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

using Trop.Application.Common.Repository;
using Trop.Domain.Common;

namespace Trop.Infrastructure.Context;

public class TropRepository<TModel> : IRepository<TModel>
    where TModel : EntityBase
{
    public TropRepository(TropContext context)
    {
        _context = context;
        _table = _context.Set<TModel>();
    }

    public TResult WithAddMap<TResult>(TModel model, Func<TModel, TResult> map)
        => map(_table.Add(model).Entity);

    public void Add(TModel model)
        => _table.Add(model);

    public TModel? FindAsDefault<TKey>(TKey keyFilter)
        => _table.Find(keyFilter);

    public TResult? WithFindMapAsDefault<TResult, TKey>(TKey keyFilter, Func<TModel?, TResult?> map)
        => map(_table.Find(keyFilter));

    public TModel? SingleAsDefault(Expression<Func<TModel, bool>> expressionFilter)
        => _table.SingleOrDefault(expressionFilter);

    public TResult? WithSingleMapAsDefault<TResult>(Expression<Func<TModel, bool>> expressionFilter, Func<TModel?, TResult?> map)
        => map(_table.SingleOrDefault(expressionFilter));

    public bool Any(Expression<Func<TModel, bool>> expression)
        => _table.Any(expression);

    public IQueryable<TModel> GetAll()
        => _table;

    private protected readonly TropContext _context;
    private protected readonly DbSet<TModel> _table;
}