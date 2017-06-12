using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace NLog.MsftTeams.Models {

  [DataContract]
  public class Payload {
    public Payload() {
      Sections = new List<Sections>();
    }

    [DataMember(Name = "sections")]
    public IList<Sections> Sections { get; set; }

    [DataMember(Name = "summary")]
    public string Summary { get; set; } = "Msft Teams Connector";

    [DataMember(Name = "themeColor")]
    public string ThemeColor { get; set; } = "0078D7";

    public string ToJson() {
      var serializer = new DataContractJsonSerializer(typeof(Payload));
      using (var memoryStream = new MemoryStream()) {
        serializer.WriteObject(memoryStream, this);
        memoryStream.Position = 0;
        using (var reader = new StreamReader(memoryStream)) {
          string json = reader.ReadToEnd();
          return json;
        }
      }
    }
  }

}