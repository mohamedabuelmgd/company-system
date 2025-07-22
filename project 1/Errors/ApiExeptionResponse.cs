namespace project_1.Errors
{
    public class ApiExeptionResponse:ApiResponse
    {
        public string Detaile { get; set; }

        public ApiExeptionResponse(int statusCode,string message=null,string details=null):base(statusCode,message)
        {
            Detaile = details;
        }
    }
}
