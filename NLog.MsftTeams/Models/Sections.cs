using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NLog.MsftTeams.Models {
  [DataContract]
  public class Sections {
    [DataMember(Name = "facts")]
    public IList<Facts> Facts { get; set; }

    [DataMember(Name = "text")]
    public string Text { get; set; }
  }
}