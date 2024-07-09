using AletheiaSoft.Application.Common.Interfaces;
using AletheiaSoft.Application.Common.Mappings;
using AletheiaSoft.Application.Common.Models;
using Microsoft.AspNetCore.Authorization;

namespace AletheiaSoft.Application.Clients.Queries.GetClientsWithPagination;

public record GetClientsWithPaginationQuery : IRequest<PaginatedList<ClientBriefDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetClientsWithPaginationQueryHandler : IRequestHandler<GetClientsWithPaginationQuery, PaginatedList<ClientBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetClientsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ClientBriefDto>> Handle(GetClientsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Clients
            .OrderBy(x => x.FullName)
            .ProjectTo<ClientBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
