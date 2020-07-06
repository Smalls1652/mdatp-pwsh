using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Identity.Client;

namespace MdatpPwsh
{
    public class PublicAuthenticationHelper
    {
        public PublicAuthenticationHelper(IPublicClientApplication app)
        {
            App = app;
        }
        protected IPublicClientApplication App { get; private set; }

        public async Task<AuthenticationResult> SilentAcquire(IEnumerable<string> scopes)
        {
            AuthenticationResult result = null;

            var accounts = await App.GetAccountsAsync();

            if (accounts.Any())
            {
                try
                {
                    result = await App.AcquireTokenSilent(scopes, accounts.FirstOrDefault())
                                        .ExecuteAsync();
                }
                catch (MsalUiRequiredException)
                {
                }
            }

            return result;
        }

        public async Task<AuthenticationResult> GetInteractive(IEnumerable<string> scopes)
        {
            AuthenticationResult result = null;

            result = await App.AcquireTokenInteractive(scopes).ExecuteAsync();

            return result;
        }

        public async Task<AuthenticationResult> GetDeviceCode(IEnumerable<string> scopes)
        {
            AuthenticationResult result = null;

            result = await App.AcquireTokenWithDeviceCode(scopes,
                deviceCodeCallback =>
                {
                    Console.WriteLine(deviceCodeCallback.Message);
                    return Task.FromResult(0);
                }).ExecuteAsync();

            return result;
        }
    }
}