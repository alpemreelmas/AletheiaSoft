using AletheiaSoft.Application.Common.Interfaces;
using AletheiaSoft.Application.Common.Mappings;
using AletheiaSoft.Application.Common.Models;

namespace AletheiaSoft.Application.Projects.Queries.GetProjectsWithPagination;

public record GetProjectsWithPaginationQuery : IRequest<PaginatedList<ProjectBriefDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetProjectsWithPaginationQueryHandler : IRequestHandler<GetProjectsWithPaginationQuery, PaginatedList<ProjectBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProjectsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ProjectBriefDto>> Handle(GetProjectsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Projects
            .OrderBy(x => x.Title)
            .ProjectTo<ProjectBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
