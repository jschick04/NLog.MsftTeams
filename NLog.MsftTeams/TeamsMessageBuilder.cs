using System;
using NLog.MsftTeams.Models;

namespace NLog.MsftTeams {

  public class TeamsMessageBuilder {
    private readonly TeamsClient _client;
    private readonly Payload _payload;
    private readonly string _webHookUrl;

    public TeamsMessageBuilder(string webHookUrl) {
      _webHookUrl = webHookUrl;
      _client = new TeamsClient();
      _payload = new Payload();
    }

    public void OnError(Action<Exception> error) {
      _client.Error += error;
    }

    public void Send() {
      _client.Send(_webHookUrl, _payload.ToJson());
    }

    public void WithMessage(string message) {
      _payload.Text = message;
    }
  }

}