﻿using EndlessSeven.Http.Abstractions;

namespace EndlessSeven.Http;

public class SetTimeRequest : ISetTimeRequest
{
    public string Token { get; set; }
    public string Command => "serverCommand";
    public string ServerCommand => "st";
    public string CommandValue { get; set; }
}