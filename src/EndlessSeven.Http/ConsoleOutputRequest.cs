using EndlessSeven.Http.Abstractions;

namespace EndlessSeven.Http;

public class ConsoleOutputRequest : IConsoleOutputRequest
{
    public string Command => "consoleOutput";
    public string Token { get; set; }
}