using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    public class RootobjectTests
    {
        [Newtonsoft.Json.JsonProperty("tests")]
        public Test[] tests { get; set; }
    }

    public class Test
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public int id { get; set; }
        [Newtonsoft.Json.JsonProperty("title")]
        public string title { get; set; }
        [Newtonsoft.Json.JsonProperty("value")]
        public string value { get; set; }
        [Newtonsoft.Json.JsonProperty("values")]
        public Test[] values { get; set; }
    }
}
