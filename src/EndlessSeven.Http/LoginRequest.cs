using EndlessSeven.Http.Abstractions;

namespace EndlessSeven.Http;

public class LoginRequest : ILoginCommandModel
{
    public string Command => "login";
    public string Password { get; set; }
}