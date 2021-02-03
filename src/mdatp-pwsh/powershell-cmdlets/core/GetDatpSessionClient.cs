using System;
using System.Management.Automation;

namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Session;

    [Cmdlet(VerbsCommon.Get, "DatpSessionClient")]
    [OutputType(typeof(DatpSessionClient))]
    public class GetDatpSessionClient : DatpCmdlet
    {
        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            DatpSessionClient sessionClient = GetSessionClient();

            WriteObject(sessionClient);
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
        }
    }
}