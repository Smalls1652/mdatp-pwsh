using System;
using System.Management.Automation;
using System.Net.Http;
using Microsoft.Identity.Client;

namespace MdatpPwsh
{
    [Cmdlet(VerbsLifecycle.Invoke, "DatpGetApiCall")]
    [CmdletBinding()]
    public class InvokeDatpGetApiCall : Cmdlet
    {
        [Parameter(Position = 0, Mandatory = true)]
        public string Uri
        {
            get { return uri; }
            set { uri = value; }
        }
        private static string uri;

        [Parameter(Position = 1, Mandatory = true)]
        public AuthenticationResult Token
        {
            get { return token; }
            set { token = value; }
        }
        private static AuthenticationResult token;

        protected override void ProcessRecord()
        {
            HttpResponseMessage apiResponse = null;

            try
            {
                apiResponse = new ApiCaller().MakeGetApiCall(uri, token);
            }
            catch (DatpException e)
            {
                ThrowTerminatingError(
                    new ErrorRecord(
                        e,
                        "Datp.ApiCall.Error",
                        ErrorCategory.InvalidResult,
                        e.DatpError.error
                    )
                );
            }

            WriteObject(apiResponse);
        }
    }
}