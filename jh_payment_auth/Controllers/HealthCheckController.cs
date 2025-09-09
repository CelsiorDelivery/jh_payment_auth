using jh_payment_auth.Models;
using Microsoft.AspNetCore.Mvc;

namespace jh_payment_auth.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/auth/[Controller]")]
    public class HealthCheckController : Controller
    {
        [HttpGet("healthcheck")]
        public ResponseModel HealthCheck()
        {
            return new ResponseModel
            {
                Message = "Health",
                StatusCode = System.Net.HttpStatusCode.OK,
                ResponseBody = "working"
            };
        }
    }
}
