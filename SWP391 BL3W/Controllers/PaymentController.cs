using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWP391_BL3W.Services.Interface;

namespace SWP391_BL3W.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private IPaymentOnlineService _vnPayService; 
        public PaymentController(IPaymentOnlineService vnPayService) 
        {
            _vnPayService = vnPayService;
        }
        [HttpGet("vn-pay/{userId}")]
        public async Task<IActionResult> PayWithUserId([FromRoute] int userId)
        {
            var result = await _vnPayService.CallAPIPayByUserId(userId);
            return Ok(result);
        }
        [HttpGet("vn-pay/check-payment")]
        public async Task<IActionResult> Check([FromQuery] string url)
        {
            var result = await _vnPayService.GetInformationPayment(url);
            return Ok(result);
        }
    }
    
}
