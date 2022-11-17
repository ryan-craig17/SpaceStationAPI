using System.Net;

namespace SpaceStationAPI.Models
{
    public class BaseResponse
    {
        public bool IsErrorResponse { get; set; }
        public string ErrorMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
