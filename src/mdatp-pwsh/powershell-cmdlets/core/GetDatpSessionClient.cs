using System;
using System.Management.Automation;

namespace MdatpPwsh
{
    using Session;

    [Cmdlet(VerbsCommon.Get, "DatpSessionClient")]
    public class GetDatpSessionClient : DatpCmdlet
    {
        protected override void ProcessRecord()
        {
            DatpSessionClient sessionClient = GetSessionClient();

            WriteObject(sessionClient);
        }
    }
}