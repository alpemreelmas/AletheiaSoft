using AletheiaSoft.Application.Clients.Commands.CreateClient;
using AletheiaSoft.Application.Common.Exceptions;
using AletheiaSoft.Domain.Entities;

namespace AletheiaSoft.Application.FunctionalTests.Clients.Commands;

using static Testing;

public class CreateClientsTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateClientCommand();
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    /*[Test]
    public async Task ShouldRequireUniqueTitle()
    {
        await SendAsync(new CreateTodoListCommand
        {
            Title = "Shopping"
        });

        var command = new CreateTodoListCommand
        {
            Title = "Shopping"
        };

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }*/

    [Test]
    public async Task ShouldCreateClient()
    {
        var userId = await RunAsDefaultUserAsync();

        var command = new CreateClientCommand()
        {
            Email = "test@test.com",
            Adress = "Test Adress",
            FullName = "Test User For Client"
        };

        var id = await SendAsync(command);

        var list = await FindAsync<Client>(id);

        list.Should().NotBeNull();
        list!.Email.Should().Be(command.Email);
        list.CreatedBy.Should().Be(userId);
        list.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    }
}
