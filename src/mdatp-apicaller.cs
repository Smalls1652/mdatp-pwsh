using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Identity.Client;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Text;

namespace mdatp_pwsh
{
    public class ApiCaller
    {
        private static string baseApiUri = "https://api.securitycenter.windows.com/api";

        public HttpResponseMessage MakeGetApiCall(string apiUri, AuthenticationResult graphToken)
        {

            HttpMethod requestMethod = HttpMethod.Get;

            HttpClient apiCaller = new HttpClient();

            string fullApiUri = $"{baseApiUri}{apiUri}";

            var apiRequest = new HttpRequestMessage(requestMethod, fullApiUri);

            apiRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", graphToken.AccessToken);

            HttpResponseMessage apiResponse = SendApiCall(apiCaller, apiRequest).GetAwaiter().GetResult();

            switch (apiResponse.StatusCode)
            {
                
                case System.Net.HttpStatusCode.BadRequest:
                case System.Net.HttpStatusCode.NotFound:
                    DatpError errorResponse = JsonConvert.DeserializeObject<DatpError>(apiResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                    throw new System.ArgumentException(errorResponse.error.message, errorResponse.error.code);

                default:
                    break;
            }

            return apiResponse;

        }

        public HttpResponseMessage MakePostApiCall(string apiUri, string apiPostBody, AuthenticationResult graphToken)
        {

            HttpMethod requestMethod = HttpMethod.Post;

            HttpClient apiCaller = new HttpClient();

            string fullApiUri = $"{baseApiUri}{apiUri}";
            var apiRequest = new HttpRequestMessage(requestMethod, fullApiUri);

            apiRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", graphToken.AccessToken);

            apiRequest.Content = new StringContent(apiPostBody);

            HttpResponseMessage apiResponse = SendApiCall(apiCaller, apiRequest).GetAwaiter().GetResult();

            switch (apiResponse.StatusCode)
            {
                
                case System.Net.HttpStatusCode.BadRequest:
                case System.Net.HttpStatusCode.NotFound:
                    DatpError errorResponse = JsonConvert.DeserializeObject<DatpError>(apiResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                    throw new System.ArgumentException(errorResponse.error.message, errorResponse.error.code);

                default:
                    break;
            }

            return apiResponse;

        }

        private async Task<HttpResponseMessage> SendApiCall(HttpClient c, HttpRequestMessage m)
        {

            HttpResponseMessage r = await c.SendAsync(m);

            return r;

        }
    }
}