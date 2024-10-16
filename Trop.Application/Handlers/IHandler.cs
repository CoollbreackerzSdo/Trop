using Ardalis.Result;

namespace Trop.Application.Handlers;

public interface IHandler<TRequest, TResult>
{
    Result<TResult> Handle(TRequest request);
}
public interface IHandlerAsync<TRequest, TResult>
{
    Task<Result<TResult>> Handle(TRequest request, CancellationToken token);
}
public interface IHandlerRequest<TRequest>
{
    Result Handle(TRequest request);
}
public interface IHandlerRequestAsync<TRequest>
{
    Task<Result> Handle(TRequest request, CancellationToken token);
}
public interface IHandlerResponse<TResult>
{
    Result<TResult> Handle();
}
public interface IHandlerResponseAsync<TResult>
{
    Task<Result<TResult>> Handle(CancellationToken token);
}