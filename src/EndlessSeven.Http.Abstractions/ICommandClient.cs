namespace EndlessSeven.Http.Abstractions;

public interface ICommandClient
{
    Task LoginAsync(ILoginCommandModel loginCommand);
    Task<string> ConsoleOutputAsync(IConsoleOutputRequest consoleOutputCommand);
    Task<ISevenDaysDateTime> GetTimeAsync(IGetTimeRequest getTimeCommand, IConsoleOutputRequest consoleOutputCommand);
    Task SetTimeAsync(ISetTimeRequest setTimeCommand);
}