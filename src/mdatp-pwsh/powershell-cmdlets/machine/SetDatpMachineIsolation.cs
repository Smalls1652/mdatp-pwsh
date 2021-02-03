using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net.Http;

using System.Text.Json;

namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Models;
    using MdatpPwsh.Helpers;

    [Cmdlet(VerbsCommon.Set, "DatpMachineIsolation")]
    public class SetDatpMachineIsolation : DatpCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true
        )]
        public string[] MachineId
        {
            get { return machineId; }
            set { machineId = value; }
        }
        private string[] machineId;

        [Parameter(
            Position = 1,
            Mandatory = true
        )]
        public string Comment
        {
            get { return cmnt; }
            set { cmnt = value; }
        }
        private string cmnt;

        [Parameter(
            Position = 2,
            Mandatory = true
        )]
        [ValidateSet(
            "Full Isolation",
            "Selective Isolation",
            "Release Isolation"
        )]
        public string IsolationType
        {
            get { return isoType; }
            set { isoType = value; }
        }
        private string isoType;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            foreach (string machine in machineId)
            {
                string apiUri;
                string apiPost;
                switch (isoType)
                {
                    case "Selective Isolation":
                        apiUri = $"machines/{machine}/isolate";
                        IsolateMachine isoSelPostObj = new IsolateMachine();
                        isoSelPostObj.Comment = cmnt;
                        isoSelPostObj.IsolationType = "Selective";
                        apiPost = JsonSerializer.Serialize<IsolateMachine>(isoSelPostObj);
                        break;

                    case "Release Isolation":
                        apiUri = $"machines/{machine}/unisolate";
                        UnIsolateMachine unIsoPost = new UnIsolateMachine();
                        unIsoPost.Comment = cmnt;
                        apiPost = JsonSerializer.Serialize<UnIsolateMachine>(unIsoPost);
                        break;

                    default:
                        apiUri = $"machines/{machine}/isolate";
                        IsolateMachine isoFullPostObj = new IsolateMachine();
                        isoFullPostObj.Comment = cmnt;
                        isoFullPostObj.IsolationType = "Full";
                        apiPost = JsonSerializer.Serialize<IsolateMachine>(isoFullPostObj);
                        break;
                }

                string apiJson = SendApiCall(apiUri, apiPost, HttpMethod.Post);

                ActivityResponse apiResult = new JsonConverter<ActivityResponse>(apiJson).Value;
                WriteObject(apiResult);
            }

        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
        }
    }
}