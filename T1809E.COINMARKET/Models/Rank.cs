using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace T1809E.COINMARKET.Models
{
    [JsonObject(IsReference = true)]
    public class Rank
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}