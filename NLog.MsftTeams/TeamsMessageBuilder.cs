using System;
using System.Collections.Generic;
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
      var section = new Sections { Text = message };
      _payload.Sections.Add(section);
    }

    public void WithServerName(string serverName, string type, string message) {
      var facts = new List<Facts> {
        new Facts { Name = "Server:", Value = serverName },
        new Facts { Name = "Type:", Value = type }
      };

      var section = new Sections { Facts = facts, Text = message };

      _payload.Sections.Add(section);
    }
  }

}