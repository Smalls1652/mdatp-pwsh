namespace MdatpPwsh
{
    namespace Classes
    {
        public class ErrorMessage
        {
            public ErrorDetails error { get; set; }
        }

        public class ErrorDetails
        {
            public string code { get; set; }
            public string message { get; set; }
            public string target { get; set; }
        }
    }
}