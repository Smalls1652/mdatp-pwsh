using System;
using System.Net;
using System.Net.Http;

using System.Text.Json;

namespace MdatpPwsh
{
    using MdatpPwsh.Models.Errors;

    [Serializable]
    public class DatpException : Exception
    {
        public ErrorMessage DatpError { get; set; }

        public DatpException(string message) : base(message) { }
        public DatpException(string message, System.Exception inner) : base(message, inner) { }
        public DatpException(string message, ErrorMessage datpError) : this(message)
        {
            DatpError = datpError;
        }
    }

    public class ErrorHandler
    {
        private ErrorMessage ConvertErrorToClass(HttpContent content)
        {
            ErrorMessage errorResponse = JsonSerializer.Deserialize<ErrorMessage>(content.ReadAsStringAsync().GetAwaiter().GetResult());

            return errorResponse;
        }

        private bool IsError(HttpStatusCode statusCode)
        {
            bool eval;

            switch (statusCode)
            {
                case HttpStatusCode.BadRequest:
                case HttpStatusCode.Unauthorized:
                case HttpStatusCode.Forbidden:
                case HttpStatusCode.NotFound:
                case HttpStatusCode.InternalServerError:
                    eval = true;
                    break;

                default:
                    eval = false;
                    break;
            }

            return eval;
        }

        public void ParseApiResponse(HttpResponseMessage response)
        {
            bool rspIsError = IsError(response.StatusCode);

            switch (rspIsError)
            {
                case true:
                    ErrorMessage errorMsg = ConvertErrorToClass(response.Content);
                    throw new DatpException(errorMsg.ErrorDetails.ErrorMessage, errorMsg);

                default:
                    break;

            }
        }
    }
}