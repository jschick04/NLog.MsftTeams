using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NLog.MsftTeams.Models {
  [DataContract]
  public class Facts {
    [DataMember(Name = "name")]
    public string Name { get; set; }

    [DataMember(Name = "value")]
    public string Value { get; set; }
  }
}
