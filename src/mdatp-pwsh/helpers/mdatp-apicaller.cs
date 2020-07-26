using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Identity.Client;
using System.Threading.Tasks;

namespace MdatpPwsh
{
    namespace ApiHelper
    {
        public class ApiCaller
        {
            public ApiCaller(string _apiUri, AuthenticationResult _graphToken)
            {
                fullApiUri = BuildApiUri(_apiUri);
                apiRequest = BuildRequestMessage(fullApiUri, HttpMethod.Get, _graphToken);
            }

            public ApiCaller(string apiUri, string apiPostBody, AuthenticationResult graphToken, HttpMethod httpMethod)
            {
                fullApiUri = BuildApiUri(apiUri);
                apiRequest = BuildRequestMessage(fullApiUri, httpMethod, graphToken);

                switch (httpMethod.Method)
                {
                    case "Post":
                    case "Patch":
                        apiRequest.Content = new StringContent(apiPostBody);
                        break;

                    default:
                        break;
                }
            }

            private HttpClient apiCaller = new HttpClient();
            private ErrorHandler errorHandler = new ErrorHandler();
            private Uri baseApiUri = new Uri("https://api.securitycenter.windows.com/api/");
            private Uri fullApiUri;
            private HttpRequestMessage apiRequest;

            public HttpResponseMessage MakeApiCall()
            {
                HttpResponseMessage apiResponse = SendApiCall(apiCaller, apiRequest).GetAwaiter().GetResult();

                errorHandler.ParseApiResponse(apiResponse);

                return apiResponse;
            }

            public void Close()
            {
                apiCaller.Dispose();
            }

            private Uri BuildApiUri(string apiUri)
            {
                Uri fullUri = new Uri(baseApiUri, apiUri);

                return fullUri;
            }

            private HttpRequestMessage BuildRequestMessage(Uri uri, HttpMethod httpMethod, AuthenticationResult graphToken)
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, uri);

                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", graphToken.AccessToken);

                return httpRequestMessage;
            }

            private async Task<HttpResponseMessage> SendApiCall(HttpClient c, HttpRequestMessage m)
            {

                HttpResponseMessage r = await c.SendAsync(m);

                return r;

            }
        }
    }
}