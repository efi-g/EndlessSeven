
using EndlessSeven.Console;
using EndlessSeven.Http;
using EndlessSeven.Http.Abstractions;
using Microsoft.Extensions.DependencyInjection;

try
{
    ConfigureService.Init();
    var service = ConfigureService.Configure();
    var client = service.GetRequiredService<ICommandClient>();

    await client.LoginAsync(service.GetRequiredService<ILoginCommandModel>());
    var sevenDaysDateTime = await client.GetTimeAsync(service.GetRequiredService<IGetTimeRequest>(),
        service.GetRequiredService<IConsoleOutputRequest>());

    await client.SetTimeAsync(new SetTimeRequest(sevenDaysDateTime));


    Console.WriteLine("set time");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}