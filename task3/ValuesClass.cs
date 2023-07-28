using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    public class RootobjectValues
    {
        [Newtonsoft.Json.JsonProperty("values")]
        public Value[] values { get; set; }
    }

    public class Value
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public int id { get; set; }
        [Newtonsoft.Json.JsonProperty("value")]
        public string value { get; set; }
    }
}
