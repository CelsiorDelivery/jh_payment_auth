using System.Net;

namespace jh_payment_auth.Models
{
    public class ResponseModel
    {
        public string ResponseBody { set; get; }
        public HttpStatusCode StatusCode { set; get; }
        public string Message { set; get; }
    }
}
