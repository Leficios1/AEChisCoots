using System.Net;

namespace SWP391_BL3W.DTO.Response
{
    public class StatusResponse<T>
    {
        public T Data { get; set; }
        public HttpStatusCode statusCode { get; set; }
        public string Errormessge { get; set; }
        public object? bonusData { get; set; }
    }
}
