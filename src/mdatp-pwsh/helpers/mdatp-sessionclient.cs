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
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", GraphToken.AccessToken); //Add the 'Bearer' property to the Authorization header.

            switch (String.IsNullOrEmpty(apiPostBody))
            {
                case false: //If apiPostBody isn't null, then set the requestMessage with the contents of the string.
                    requestMessage.Content = new StringContent(apiPostBody);
                    break;

                default: //If apiPostBody is null, then do nothing.
                    break;
            }

            //Send the request and return the contents as a string.
            HttpResponseMessage responseMessage = GraphClient.SendAsync(requestMessage).GetAwaiter().GetResult(); //Need to handle the async method differently
            new ErrorHandler().ParseApiResponse(responseMessage);
            string responseMessageString = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult(); //Need to handle the async method differently

            return responseMessageString;
        }
    }
}