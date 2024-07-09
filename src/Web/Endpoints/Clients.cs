using AletheiaSoft.Application.Clients.Commands.CreateClient;
using AletheiaSoft.Application.Clients.Commands.DeleteClient;
using AletheiaSoft.Application.Clients.Commands.UpdateClient;
using AletheiaSoft.Application.Clients.Queries.GetClientsWithPagination;
using AletheiaSoft.Application.Common.Models;
using Microsoft.AspNetCore.Authorization;

namespace AletheiaSoft.Web.Endpoints;

public class Clients : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetClientsWithPagination)
            .MapPost(CreateClient)
            .MapPut(UpdateClient, "{id}")
            .MapDelete(DeleteClient, "{id}");
    }

    [Authorize]
    public Task<PaginatedList<ClientBriefDto>> GetClientsWithPagination(ISender sender, [AsParameters] GetClientsWithPaginationQuery query)
    {
        return sender.Send(query);
    }

    public Task<int> CreateClient(ISender sender, CreateClientCommand command)
    {
        return sender.Send(command);
    }

    public async Task<IResult> UpdateClient(ISender sender, int id, UpdateClientCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }
    

    public async Task<IResult> DeleteClient(ISender sender, int id)
    {
        await sender.Send(new DeleteClientCommand(id));
        return Results.NoContent();
    }
}
