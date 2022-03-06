using EndlessSeven.Http;
using EndlessSeven.Http.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace EndlessSeven.Console;

public class ConfigureService
{
    public static IServiceProvider Configure()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddHttpClient<ICommandClient, CommandClient>(client => new CommandClient())

        return serviceCollection
            .BuildServiceProvider();
    }
}