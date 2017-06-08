﻿using System;
using System.Net;
using System.Text;

namespace NLog.MsftTeams {

  public class TeamsClient {
    public event Action<Exception> Error;

    public void Send(string url, string data) {
      try {
        using (var client = new WebClient()) {
          client.Headers[HttpRequestHeader.ContentType] = "application/json";
          client.Encoding = Encoding.UTF8;
          client.UploadString(url, "POST", data);
        }
      } catch (Exception e) {
        OnError(e);
      }
    }

    private void OnError(Exception obj) {
      Error?.Invoke(obj);
    }
  }

}