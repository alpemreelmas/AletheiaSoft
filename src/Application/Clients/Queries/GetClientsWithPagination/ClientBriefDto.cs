using AletheiaSoft.Domain.Entities;

namespace AletheiaSoft.Application.Clients.Queries.GetClientsWithPagination;

public class ClientBriefDto
{
    public int Id { get; init; }

    public string? FullName { get; init; }
    
    public string? ProfilePic { get; init; }
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Client, ClientBriefDto>();
        }
    }
}
