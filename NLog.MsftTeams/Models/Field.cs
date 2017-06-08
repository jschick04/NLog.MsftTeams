using System.Runtime.Serialization;

namespace NLog.MsftTeams.Models {

  [DataContract]
  public class Field {
    public Field(string title) {
      Title = title;
    }

    [DataMember(Name = "short")]
    public bool Short { get; set; }

    [DataMember(Name = "title")]
    public string Title { get; set; }

    [DataMember(Name = "value")]
    public string Value { get; set; }
  }

}