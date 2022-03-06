namespace EndlessSeven.Http.Abstractions;

public interface ICommandModel : ITokenModel
{
    string Command { get; }
}