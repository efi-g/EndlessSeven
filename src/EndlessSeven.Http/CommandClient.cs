using EndlessSeven.Http.Abstractions;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace EndlessSeven.Http;

public class CommandClient : ICommandClient
{
    private string UrlBase { get; }
    private string RelativeUrl => "/api/command";
    private string CurrentToken { get; set; }

    private HttpClient HttpClient { get; }

    public CommandClient(HttpClient httpClient, string urlBase)
    {
        HttpClient = httpClient;
        UrlBase = urlBase;
    }

    private string SetCurrentToken(string responseString)
    {
        var responseData = responseString.Split('^');
        CurrentToken = responseData[0];

        return responseData[1];
    }

    public async Task LoginAsync(ILoginCommandModel loginCommand)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, new Uri($"{UrlBase}{RelativeUrl}"));
        var content = new StringContent(loginCommand.ToCommand(), Encoding.UTF8, "application/x-www-form-urlencoded");
        request.Content = content;

        var response = await HttpClient.SendAsync(request);

        var body = await response.Content.ReadAsStringAsync();

        SetCurrentToken(body);
    }

    public async Task<string> ConsoleOutputAsync(IConsoleOutputRequest consoleOutputCommand)
    {
        consoleOutputCommand.Token = CurrentToken;

        var request = new HttpRequestMessage(HttpMethod.Post, new Uri($"{UrlBase}{RelativeUrl}"));
        var content = new StringContent(consoleOutputCommand.ToCommand(), Encoding.UTF8, "application/x-www-form-urlencoded");
        request.Content = content;

        var response = await HttpClient.SendAsync(request);

        var body = await response.Content.ReadAsStringAsync();

        return SetCurrentToken(body);
    }

    public async Task<ISevenDaysDateTime> GetTimeAsync(IGetTimeRequest getTimeCommand, IConsoleOutputRequest consoleOutputCommand)
    {
        getTimeCommand.Token = CurrentToken;

        var request = new HttpRequestMessage(HttpMethod.Post, new Uri($"{UrlBase}{RelativeUrl}"));
        var content = new StringContent(getTimeCommand.ToCommand(), Encoding.UTF8, "application/x-www-form-urlencoded");
        request.Content = content;

        var response = await HttpClient.SendAsync(request);

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception("request error");
        }

        SetCurrentToken(await response.Content.ReadAsStringAsync());

        var responseData = await ConsoleOutputAsync(consoleOutputCommand);
        var matches = Regex.Matches(responseData.Split("<br>")[^2], @"Day (\d+), (\d+):(\d+)");
        if (matches.Count == 0)
        {
            throw new Exception("match error");
        }
        return new SevenDaysDateTime(matches[0].Groups[1].Value, matches[0].Groups[2].Value, matches[0].Groups[3].Value);
    }

    public async Task SetTimeAsync(ISetTimeRequest setTimeCommand)
    {
        setTimeCommand.Token = CurrentToken;

        var request = new HttpRequestMessage(HttpMethod.Post, new Uri($"{UrlBase}{RelativeUrl}"));
        var content = new StringContent(setTimeCommand.ToCommand(), Encoding.UTF8, "application/x-www-form-urlencoded");
        request.Content = content;

        var response = await HttpClient.SendAsync(request);

        SetCurrentToken(await response.Content.ReadAsStringAsync());
    }
}