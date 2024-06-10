using AletheiaSoft.Domain.Entities;

namespace AletheiaSoft.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }
    DbSet<Client> Clients { get; }
    DbSet<Project> Projects { get; }
    

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
