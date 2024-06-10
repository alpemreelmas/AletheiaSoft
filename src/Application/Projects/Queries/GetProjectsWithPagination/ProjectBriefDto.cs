using AletheiaSoft.Domain.Entities;

namespace AletheiaSoft.Application.Projects.Queries.GetProjectsWithPagination;

public class ProjectBriefDto
{
    public int Id { get; init; }

    public string? Title { get; init; }
    public int? Budget { get; init; }
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Project, ProjectBriefDto>();
        }
    }
}
