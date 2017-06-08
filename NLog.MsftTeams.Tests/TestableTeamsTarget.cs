using NLog.Common;

namespace NLog.MsftTeams.Tests {

  public class TestableTeamsTarget : TeamsTarget {
    public void Initialize() {
      InitializeTarget();
    }

    public new void Write(AsyncLogEventInfo eventInfo) {
      base.Write(eventInfo);
    }
  }

}