using jh_payment_auth.Models;
using Microsoft.AspNetCore.Mvc;

namespace jh_payment_auth.Controllers
{
    /// <summary>
    /// This controller provides a health check endpoint to verify that the authentication service is operational.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/auth-service/[Controller]")]
    public class HealthCheckController : Controller
    {
        /// <summary>
        /// The health check endpoint to verify that the service is running.
        /// </summary>
        /// <returns></returns>
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
