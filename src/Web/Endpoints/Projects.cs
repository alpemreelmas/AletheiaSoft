using AletheiaSoft.Application.Clients.Commands.CreateClient;
using AletheiaSoft.Application.Clients.Commands.DeleteClient;
using AletheiaSoft.Application.Clients.Commands.UpdateClient;
using AletheiaSoft.Application.Clients.Queries.GetClientsWithPagination;
using AletheiaSoft.Application.Common.Models;
using AletheiaSoft.Application.Projects.Commands.CreateProject;
using AletheiaSoft.Application.Projects.Commands.DeleteProject;
using AletheiaSoft.Application.Projects.Commands.UpdateProject;
using AletheiaSoft.Application.Projects.Queries.GetProjectsWithPagination;

namespace AletheiaSoft.Web.Endpoints;

public class Projects : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetProjectsWithPagination)
            .MapPost(CreateProject)
            .MapPut(UpdateProject, "{id}")
            .MapDelete(DeleteProject, "{id}");
    }

    public Task<PaginatedList<ProjectBriefDto>> GetProjectsWithPagination(ISender sender, [AsParameters] GetProjectsWithPaginationQuery query)
    {
        return sender.Send(query);
    }

    public Task<int> CreateProject(ISender sender, CreateProjectCommand command)
    {
        return sender.Send(command);
    }

    public async Task<IResult> UpdateProject(ISender sender, int id, UpdateProjectCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }
    

    public async Task<IResult> DeleteProject(ISender sender, int id)
    {
        await sender.Send(new DeleteProjectCommand(id));
        return Results.NoContent();
    }
}
