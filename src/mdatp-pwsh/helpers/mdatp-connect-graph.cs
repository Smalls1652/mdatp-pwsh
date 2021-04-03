using System;
using System.Linq;
using System.Threading;
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
        private IPublicClientApplication App { get; set; }

        public async Task<AuthenticationResult> StartAcquire(IEnumerable<string> scopes, CancellationToken token)
        {
            AuthenticationResult result = null;

            var accounts = await App.GetAccountsAsync();
            if (accounts.Any()) //This step currently doesn't work as expected. TokenCache is not configured for this module yet.
            {
                result = await App.AcquireTokenSilent(scopes, accounts.FirstOrDefault())
                    .ExecuteAsync();
            }
            else
            {
                result = await GetDeviceCode(scopes, token); //Run the device code flow
            }

            return result;
        }

        public async Task<AuthenticationResult> GetDeviceCode(IEnumerable<string> scopes, CancellationToken token)
        {
            AuthenticationResult result = null;
            try
            {
                result = await App.AcquireTokenWithDeviceCode(
                    scopes,
                    deviceCodeCallback =>
                    {
                        Console.WriteLine(deviceCodeCallback.Message); //Write the device code message to the console

                        Task resultFromTask = null;
                        if (token.IsCancellationRequested)
                        {
                            token.ThrowIfCancellationRequested(); //Cancel the token acquisition process if the 'cancel' signal is sent.
                        }
                        else
                        {
                            resultFromTask = Task.FromResult(0); //Set the result from the task
                        }

                        return resultFromTask; //End the callback and return with the token acquired
                    }
                ).ExecuteAsync(token);
            }
            catch (MsalServiceException e)
            {
                throw e;
            }
            catch (OperationCanceledException e)
            {
                throw e;
            }
            catch (MsalClientException e)
            {
                throw e;
            }

            return result;
        }
    }
}