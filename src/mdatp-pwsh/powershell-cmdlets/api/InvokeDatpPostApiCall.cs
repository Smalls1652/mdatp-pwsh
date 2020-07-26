using System.Management.Automation;
using System.Net.Http;
using Microsoft.Identity.Client;

using MdatpPwsh.ApiHelper;

namespace MdatpPwsh
{
    [Cmdlet(VerbsLifecycle.Invoke, "DatpPostApiCall")]
    [CmdletBinding()]
    public class InvokeDatpPostApiCall : Cmdlet
    {
        [Parameter(Position = 0, Mandatory = true)]
        public string Uri
        {
            get { return uri; }
            set { uri = value; }
        }
        private static string uri;

        [Parameter(Position = 1, Mandatory = true)]
        public string PostBody
        {
            get { return postBody; }
            set { postBody = value; }
        }
        private static string postBody;

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
                ApiCaller apiCaller = new ApiCaller(uri, postBody, token, HttpMethod.Post);
                apiResponse = apiCaller.MakeApiCall();
                apiCaller.Close();
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