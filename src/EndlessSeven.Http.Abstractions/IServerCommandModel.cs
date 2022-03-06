namespace EndlessSeven.Http.Abstractions;

public interface IServerCommandModel : ICommandModel
{
    string ServerCommand { get; }
    string CommandValue { get; set; }
}