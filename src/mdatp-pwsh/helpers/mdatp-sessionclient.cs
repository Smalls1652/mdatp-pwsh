using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using Microsoft.Identity.Client;

namespace MdatpPwsh.Session
{
    using MdatpPwsh.Models;
    public class DatpSessionClient
    {
        public DatpSessionClient() { }

        public DatpSessionClient(Uri baseApiUri, AuthenticationResult graphToken, IPublicClientApplication app)
        {
            BaseApiUri = baseApiUri;
            GraphToken = graphToken;
            App = app;
            Connect();
        }

        public Uri BaseApiUri { get; set; }
        public AuthenticationResult GraphToken { get; set; }
        public IPublicClientApplication App { get; set; }
        public HttpClient GraphClient { get; set; }

        public void Connect()
        {
            GraphClient = new HttpClient();
            GraphClient.BaseAddress = BaseApiUri;
        }

        public string SendApiCall(string endpoint, string apiPostBody, HttpMethod httpMethod)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(httpMethod, endpoint);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", GraphToken.AccessToken);

            switch (String.IsNullOrEmpty(apiPostBody))
            {
                case false:
                    requestMessage.Content = new StringContent(apiPostBody);
                    break;

                default:
                    break;
            }

            HttpResponseMessage responseMessage = GraphClient.SendAsync(requestMessage).GetAwaiter().GetResult();
            new ErrorHandler().ParseApiResponse(responseMessage);
            string responseMessageString = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            return responseMessageString;
        }
    }
}