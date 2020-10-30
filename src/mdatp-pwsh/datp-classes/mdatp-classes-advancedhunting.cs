using System;
using System.Management.Automation;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MdatpPwsh
{
    namespace Classes
    {
        public class AdvancedHuntingResponse
        {
            [JsonProperty("schema")]
            public List<object> Schema { get; set; }

            [JsonProperty("results")]
            public string Results { get; set; }
        }

        public class AdvancedHuntingResult : PSObject
        {

        }

        public class AdvancedHuntingPost
        {
            public AdvancedHuntingPost() { }

            public AdvancedHuntingPost(string query)
            {
                Query = query;
            }

            [JsonProperty("Query")]
            public string Query { get; set; }
        }
    }
}