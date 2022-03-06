using System.Web;
using EndlessSeven.Http.Abstractions;

namespace EndlessSeven.Http;

public static class CommandExtensions
{
    public static string ToCommand(this ICommandModel model)
        => $"command={model.Command}&token={model.Command}";

    public static string ToCommand(this IServerCommandModel model)
    {
        var serverCommand = string.IsNullOrEmpty(model.CommandValue)
            ? model.ServerCommand
            : HttpUtility.UrlEncode($"{model.ServerCommand} {model.CommandValue}");

        return $"command={model.Command}&serverCommand={serverCommand}&token={model.Token}";
    }

    public static string ToCommand(this ILoginCommandModel model)
        => $"command={model.Command}&password={model.Password}";
}