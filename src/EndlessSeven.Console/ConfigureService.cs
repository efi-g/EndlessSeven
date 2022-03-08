using EndlessSeven.Http;
using EndlessSeven.Http.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EndlessSeven.Console;

public class ConfigureService
{
    public static IConfigurationRoot Config { get; set; }

    public static void Init()
    {
        Config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
    }

    public static IServiceProvider Configure()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddHttpClient<ICommandClient, CommandClient>(client
            => new CommandClient(client, Config["base_url"]));

        serviceCollection.AddSingleton<ILoginCommandModel, LoginRequest>(services
            => new LoginRequest() { Password = Config["password"] });
        serviceCollection.AddSingleton<IConsoleOutputRequest, ConsoleOutputRequest>();
        serviceCollection.AddSingleton<IGetTimeRequest, GetTimeRequest>();


        return serviceCollection
            .BuildServiceProvider();
    }
}