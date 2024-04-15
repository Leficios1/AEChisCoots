using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWP391_BL3W.Database;
using SWP391_BL3W.DTO.Request;
using SWP391_BL3W.Services;
using SWP391_BL3W.Services.Interface;
using System.Drawing;

namespace SWP391_BL3W.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly SWPContext _context;

        public OrderController(IOrderService orderService, SWPContext context)
        {
            _orderService = orderService;
            _context = context;
        }

        [HttpPost("create")]
        public async Task<IActionResult> create(OrderResquestDTO dto)
        {
            var response = await _orderService.create(dto);
            return StatusCode((int)response.statusCode, new { data = response.Data, message = response.Errormessge });
        }
    }
}
