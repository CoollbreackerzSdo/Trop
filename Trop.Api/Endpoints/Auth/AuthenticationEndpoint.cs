using System.IdentityModel.Tokens.Jwt;

using Ardalis.Result;

using Microsoft.AspNetCore.Http.HttpResults;

using Trop.Api.Endpoints.Common;
using Trop.Api.Services.Authentication.JsonWebToken;
using Trop.Application.Handlers;
using Trop.Application.Handlers.Common;
using Trop.Application.Handlers.Create;
using Trop.Application.Handlers.Read;

namespace Trop.Api.Endpoints.Auth;

public class AuthenticationEndpoint : IEndpoint
{
    public void Map(IEndpointRouteBuilder builder)
    {
        var api = builder.MapGroup("auth");

        api.MapPost("sign-up", SignUp)
            .AddEndpointFilter<ValidationFilter<CreateUserCommandHandler>>()
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status409Conflict)
            .ProducesProblem(StatusCodes.Status403Forbidden);

        api.MapPost("sign-in", SignIn)
            .AddEndpointFilter<ValidationFilter<ValidateUserCommandHandler>>()
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound);
    }
    public static Results<Ok<string>, ValidationProblem, BadRequest<string>, NotFound> SignIn(ValidateUserCommandHandler command, IHandler<ValidateUserCommandHandler, UserCredentials> handler, IJsonWebTokenGenerator generator)
    {
        var handlerResult = handler.Handle(command);
        if (handlerResult.IsSuccess)
        {
            var credentials = handlerResult.Value;
            return TypedResults.Ok(generator.GenerateToken([
                new(JwtRegisteredClaimNames.Sub,credentials.Key.ToString()),
                new(JwtRegisteredClaimNames.Email,credentials.Email),
                new(JwtRegisteredClaimNames.UniqueName,credentials.UserName)
            ]));
        }
        return handlerResult.Status switch
        {
            ResultStatus.Invalid => TypedResults.BadRequest("Nombre de usuario o contraseña no valida"),
            _ => TypedResults.NotFound()
        };
    }

    public static async Task<Results<Ok<string>, NotFound, Conflict, ForbidHttpResult, ValidationProblem>> SignUp(CreateUserCommandHandler command, IJsonWebTokenGenerator generator, IHandlerAsync<CreateUserCommandHandler, UserCredentials> handlerAsync, CancellationToken token)
    {
        var handlerResult = await handlerAsync.HandleAsync(command, token);
        if (handlerResult.IsSuccess)
        {
            var credentials = handlerResult.Value;
            return TypedResults.Ok(generator.GenerateToken([
                new(JwtRegisteredClaimNames.Sub,credentials.Key.ToString()),
                new(JwtRegisteredClaimNames.Email,credentials.Email),
                new(JwtRegisteredClaimNames.UniqueName,credentials.UserName)
            ]));
        }
        return handlerResult.Status switch
        {
            ResultStatus.Forbidden => TypedResults.Forbid(),
            ResultStatus.Conflict => TypedResults.Conflict(),
            _ => TypedResults.NotFound()
        };
    }
}