using System.Runtime.Serialization;

namespace NLog.MsftTeams.Models {

  [DataContract]
  public class Response {
    [DataMember(Name = "error")]
    public string Error { get; set; }

    public bool HasError => !Ok || string.IsNullOrWhiteSpace(Error);

    [DataMember(Name = "ok")]
    public bool Ok { get; set; }
  }

}