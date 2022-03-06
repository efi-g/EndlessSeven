using EndlessSeven.Http.Abstractions;

namespace EndlessSeven.Http;

public class GetTimeRequest : IGetTimeRequest
{
    public string Token { get; set; }
    public string Command => "serverCommand";
    public string ServerCommand => "gt";
    public string CommandValue { get; set; }
}