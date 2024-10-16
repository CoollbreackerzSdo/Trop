using System;

namespace Trop.Api.Endpoints;

public interface IEndpoint
{
    void Map(IEndpointRouteBuilder builder);
}