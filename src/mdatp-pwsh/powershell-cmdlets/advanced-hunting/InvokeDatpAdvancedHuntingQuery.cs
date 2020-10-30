using System;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.PowerShell.Commands;
using System.Net.Http;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MdatpPwsh
{
    using Classes;

    [Cmdlet(VerbsLifecycle.Invoke, "DatpAdvancedHuntingQuery")]
    public class InvokeDatpAdvancedHuntingQuery : DatpCmdlet
    {
        [Parameter(Position = 0, Mandatory = true)]
        public string Query
        {
            get { return query; }
            set { query = value; }
        }

        private string query;
        private string apiUri;

        protected override void BeginProcessing()
        {
            apiUri = "advancedqueries/run";
        }

        protected override void ProcessRecord()
        {
            AdvancedHuntingPost postObj = new AdvancedHuntingPost(query);
            string apiPost = JsonConvert.SerializeObject(postObj);

            WriteVerbose("Starting api call");
            string apiJson = SendApiCall(apiUri, apiPost, HttpMethod.Post);

            JArray apiResponse = JsonConvert.DeserializeObject<JArray>(JObject.Parse(apiJson)["Results"].ToString());
            WriteObject(apiResponse);
/*
            foreach (JObject item in apiResponse["Results"])
            {
                item.PRo
            }
*/
        }
    }
}