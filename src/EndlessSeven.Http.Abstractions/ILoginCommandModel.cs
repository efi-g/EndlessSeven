namespace EndlessSeven.Http.Abstractions;

public interface ILoginCommandModel
{
    string Command { get; }
    string Password { get; set; }
}