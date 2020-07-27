using System.Management.Automation;
using System.Net.Http;
using Microsoft.Identity.Client;

using MdatpPwsh.ApiHelper;

namespace MdatpPwsh
{
    [Cmdlet(VerbsLifecycle.Invoke, "DatpApiCall")]
    [CmdletBinding()]
    public class InvokeDatpApiCall : Cmdlet
    {
        public InvokeDatpApiCall() { }

        public InvokeDatpApiCall(string ApiUri, AuthenticationResult Token, HttpMethod Method)
        {
            apiUri = ApiUri;
            token = Token;
            method = Method;
        }

        public InvokeDatpApiCall(string ApiUri, AuthenticationResult Token, HttpMethod Method, string Body)
        {
            apiUri = ApiUri;
            token = Token;
            method = Method;
            body = Body;
        }

        [Parameter(Position = 0, Mandatory = true)]
        public string ApiUri
        {
            get { return apiUri; }
            set { apiUri = value; }
        }

        [Parameter(Position = 1, Mandatory = true)]
        public AuthenticationResult Token
        {
            get { return token; }
            set { token = value; }
        }

        [Parameter(Position = 2)]
        public HttpMethod Method
        {
            get { return method; }
            set { method = value; }
        }

        [Parameter(Position = 3)]
        public string Body
        {
            get { return body; }
            set { body = value; }
        }

        private string apiUri;
        private AuthenticationResult token;
        private HttpMethod method = HttpMethod.Get;
        private string body;

        protected override void ProcessRecord()
        {
            HttpResponseMessage apiResponse = null;
            ApiCaller apiCaller;

            try
            {
                apiCaller = new ApiCaller(apiUri, body, token, method);
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