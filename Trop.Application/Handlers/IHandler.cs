namespace Trop.Application.Handlers;

public interface IHandler<TRequest, TResult>
{
    Result<TResult> Handle(TRequest request);
}
public interface IHandlerAsync<TRequest, TResult>
{
    Task<Result<TResult>> HandleAsync(TRequest request, CancellationToken token);
}
public interface IHandlerRequest<TRequest>
{
    Result Handle(TRequest request);
}
public interface IHandlerRequestAsync<TRequest>
{
    Task<Result> HandleHandleAsync(TRequest request, CancellationToken token);
}
public interface IHandlerResponse<TResult>
{
    Result<TResult> Handle();
}
public interface IHandlerResponseAsync<TResult>
{
    Task<Result<TResult>> HandleHandleAsync(CancellationToken token);
}