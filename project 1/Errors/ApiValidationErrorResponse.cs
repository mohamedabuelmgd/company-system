using System.Collections;
using System.Collections.Generic;

namespace project_1.Errors
{
    public class ApiValidationErrorResponse:ApiResponse
    {

        public IEnumerable<string> Errors { get; set; }
        public ApiValidationErrorResponse():base(400)
        {

        }
    }
}
