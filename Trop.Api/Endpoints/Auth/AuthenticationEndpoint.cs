using System.IdentityModel.Tokens.Jwt;

using Ardalis.Result;

using Microsoft.AspNetCore.Http.HttpResults;

using Trop.Api.Endpoints.Common;
using Trop.Api.Handlers.Authentication.JsonWebToken;
using Trop.Application.Handlers;
using Trop.Application.Handlers.Common;
using Trop.Application.Handlers.Create;

namespace Trop.Api.Endpoints.Auth;

public class AuthenticationEndpoint : IEndpoint
{
    public void Map(IEndpointRouteBuilder builder)
    {
        var api = builder.MapGroup("auth");

        api.MapPost("sign-up", SignUp)
            .AddEndpointFilter<ValidationFilter<CreateUserCommandHandler>>()
            .Produces(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status409Conflict);
    }

    public static async Task<Results<Ok<string>, NotFound, Conflict, ValidationProblem>> SignUp(CreateUserCommandHandler command, JsonWebTokenGenerator generator, IHandlerAsync<CreateUserCommandHandler, UserCredentials> handlerAsync, CancellationToken token)
    {
        var handlerResult = await handlerAsync.HandleAsync(command, token);
        if (handlerResult.IsSuccess)
        {
            var credentials = handlerResult.Value;
            return TypedResults.Ok(generator.Generate([
                new(JwtRegisteredClaimNames.Sub,credentials.Key.ToString()),
                new(JwtRegisteredClaimNames.Email,credentials.Email),
                new(JwtRegisteredClaimNames.UniqueName,credentials.UserName)
            ]));
        }
        else if (handlerResult.IsConflict())
        {
            return TypedResults.Conflict();
        }
        return TypedResults.NotFound();
    }
}