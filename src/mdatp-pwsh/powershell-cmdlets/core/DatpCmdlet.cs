using System;
using System.Management.Automation;
using System.Net.Http;

namespace MdatpPwsh.Cmdlets
{
    using MdatpPwsh.Session;
    public abstract class DatpCmdlet : PSCmdlet
    {
        protected DatpSessionClient GetSessionClient()
        {
            DatpSessionClient sessionClient = (DatpSessionClient)SessionState.PSVariable.GetValue("DatpSessionClient");

            if (null == sessionClient)
            {
                throw new Exception("DATP session client not found.");
            }

            return sessionClient;
        }

        protected string SendApiCall(string uri, string body, HttpMethod httpMethod)
        {
            DatpSessionClient sessionClient = GetSessionClient();

            string apiResponse = sessionClient.SendApiCall(uri, body, httpMethod);

            return apiResponse;
        }
    }
}