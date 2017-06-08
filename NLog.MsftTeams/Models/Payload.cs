using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace NLog.MsftTeams.Models {

  [DataContract]
  public class Payload {
    [DataMember(Name = "text")]
    public string Text { get; set; }
    
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
