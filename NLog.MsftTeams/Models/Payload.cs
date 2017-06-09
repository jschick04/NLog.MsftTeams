using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace NLog.MsftTeams.Models {

  [DataContract]
  public class Payload {
    [DataMember(Name = "themeColor")]
    public string ThemeColor { get; set; } = "0078D7";

    [DataMember(Name = "sections")]
    public IList<Sections> Sections { get; set; }
    
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
