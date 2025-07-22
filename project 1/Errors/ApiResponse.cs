using System;

namespace project_1.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A Bad Request , You Have Made",
                401 => "Authorized, you are not",
                404 => "Resource found ,It was not ",
                500 => " Errors Are the Path To the Dark Side",
                _ => null

            };
        }
    }
}
