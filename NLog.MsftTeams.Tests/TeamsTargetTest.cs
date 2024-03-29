﻿using System;
using NLog.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NLog.MsftTeams.Tests {

  [TestClass]
  public class TeamsTargetTests {
    [TestMethod]
    public void CustomSettings_ShouldBeCorrect() {
      const string webHookUrl = "http://teams.webhook.test";

      var teamsTarget = new TestableTeamsTarget {
        WebHookUrl = webHookUrl
      };

      Assert.AreEqual(webHookUrl, teamsTarget.WebHookUrl);
    }

    [TestMethod]
    public void DefaultSettings_ShouldBeCorrect() {
      var teamsTarget = new TestableTeamsTarget();

      Assert.IsNull(teamsTarget.WebHookUrl);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void InitializeTarget_EmptyWebHookUrl_ShouldThrowException() {
      var teamsTarget = new TestableTeamsTarget();

      teamsTarget.Initialize();
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void InitializeTarget_IncorrectWebHookUrl_ShouldThrowException() {
      var teamsTarget = new TestableTeamsTarget {
        WebHookUrl = "Invalid URL"
      };

      teamsTarget.Initialize();
    }

    [TestMethod]
    public void InitializeTarget_DefaultJson() {
      var teamsTarget = new TestableTeamsTarget {
        WebHookUrl = "http://teams.webhook.test"
      };

      teamsTarget.Initialize();

      Logger log = LogManager.GetCurrentClassLogger();
      log.Info("Test Message");

      teamsTarget.Write(new AsyncLogEventInfo(LogEventInfo.Create(LogLevel.Info, "Test", "Test Message"), null));
    }
  }

}