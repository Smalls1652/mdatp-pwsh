using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Identity.Client;
using System.Threading.Tasks;

namespace MdatpPwsh
{
    public class ApiCaller
    {
        private ErrorHandler errorHandler = new ErrorHandler();
        private Uri baseApiUri = new Uri("https://api.securitycenter.windows.com/api/");

        public HttpResponseMessage MakeGetApiCall(string apiUri, AuthenticationResult graphToken)
        {

            HttpMethod requestMethod = HttpMethod.Get;

            HttpClient apiCaller = new HttpClient();

            Uri fullApiUri = new Uri(baseApiUri, apiUri);

            var apiRequest = new HttpRequestMessage(requestMethod, fullApiUri);

            apiRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", graphToken.AccessToken);

            HttpResponseMessage apiResponse = SendApiCall(apiCaller, apiRequest).GetAwaiter().GetResult();
            
            errorHandler.ParseApiResponse(apiResponse);

            return apiResponse;

        }

        public HttpResponseMessage MakePostApiCall(string apiUri, string apiPostBody, AuthenticationResult graphToken)
        {

            HttpMethod requestMethod = HttpMethod.Post;

            HttpClient apiCaller = new HttpClient();

            Uri fullApiUri = new Uri(baseApiUri, apiUri);
            var apiRequest = new HttpRequestMessage(requestMethod, fullApiUri);

            apiRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", graphToken.AccessToken);

            apiRequest.Content = new StringContent(apiPostBody);

            HttpResponseMessage apiResponse = SendApiCall(apiCaller, apiRequest).GetAwaiter().GetResult();

            errorHandler.ParseApiResponse(apiResponse);

            return apiResponse;

        }

        private async Task<HttpResponseMessage> SendApiCall(HttpClient c, HttpRequestMessage m)
        {

            HttpResponseMessage r = await c.SendAsync(m);

            return r;

        }
    }
}