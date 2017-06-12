using System;
using NLog.Common;
using NLog.Config;
using NLog.Layouts;
using NLog.Targets;

namespace NLog.MsftTeams {

  [Target("MsftTeams")]
  public class TeamsTarget : TargetWithLayout {
    [RequiredParameter]
    public string WebHookUrl { get; set; }

    public SimpleLayout ServerName { get; set; }

    public SimpleLayout EventLevel { get; set; }

    protected override void InitializeTarget() {
      if (string.IsNullOrWhiteSpace(WebHookUrl)) {
        throw new ArgumentOutOfRangeException("WebHookUrl", "Webhook URL cannot be empty.");
      }

      Uri uriResult;
      if (!Uri.TryCreate(WebHookUrl, UriKind.Absolute, out uriResult)) {
        throw new ArgumentOutOfRangeException("WebHookUrl", "Webhook URL is an invalid URL.");
      }

      base.InitializeTarget();
    }

    protected override void Write(AsyncLogEventInfo info) {
      try {
        SendToTeams(info);
      } catch (Exception e) {
        info.Continuation(e);
      }
    }

    private void SendToTeams(AsyncLogEventInfo info) {
      string message = Layout.Render(info.LogEvent);
      var teams = new TeamsMessageBuilder(WebHookUrl);
      teams.OnError(e => info.Continuation(e));

      if (string.IsNullOrWhiteSpace(ServerName.Render(info.LogEvent))) {
        teams.WithMessage(message);
      } else {
        teams.WithServerName(ServerName.Render(info.LogEvent), EventLevel.Render(info.LogEvent), message);
      }

      teams.Send();
    }
  }

}