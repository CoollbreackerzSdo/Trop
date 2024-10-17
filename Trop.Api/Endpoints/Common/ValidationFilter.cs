using FluentValidation;

namespace Trop.Api.Endpoints.Common;

public class ValidationFilter<T>(IValidator<T> validator, ILogger<ValidationFilter<T>> logger) : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var validationResult = validator.Validate(context.GetArgument<T>(0));
        if (validationResult.IsValid)
        {
            return await next(context);
        }
        logger.LogInformation("Validation problem in {} for {}", [context.HttpContext.Request.Path, context.HttpContext.Request.QueryString]);
        return TypedResults.ValidationProblem(validationResult.ToDictionary());
    }
}