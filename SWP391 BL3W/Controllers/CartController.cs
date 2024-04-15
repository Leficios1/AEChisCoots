using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWP391_BL3W.DTO.Request;
using SWP391_BL3W.Services.Interface;

namespace SWP391_BL3W.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        public ICartService _cartService { get; set; }
        public CartController(ICartService cartService) 
        { 
            this._cartService = cartService;
        }
        [HttpGet("get-by-user-id/{userId}")]
        public async Task<IActionResult> GetByUserId([FromRoute] int userId) 
        {
            var result = await _cartService.GetCartsByUserId(userId);
            return Ok(result);
        }
        [HttpPut("cart-to-new-order/by-user-id/{userId}")]
        public async Task<IActionResult> CompletedToConvertToOrder([FromRoute] int userId, [FromBody] PaymentDTO paymentDTO)
        {
            var result = await _cartService.CompletedPaymentCartToOrder(userId,paymentDTO);
            return Ok(result);
        }
        [HttpPost("add-product-into-cart/{productId}/{userId}")]
        public async Task<IActionResult> AddToCart([FromRoute] int productId, [FromRoute] int userId)
        {
            var result = await _cartService.AddProductToCartByUserId(productId,userId);
            return Ok(result);
        }
        [HttpDelete("delete-all-carts-by-user-id/{userId}")]
        public async Task<IActionResult> DeleteAllCartsByUserId([FromRoute] int userId)
        {
            var result = await _cartService.DeleteAllProductsInCartByUserId(userId);
            return Ok(result);
        }
        [HttpDelete("delete-product-id-by-user-id/{productId}/{userId}")]
        public async Task<IActionResult> DeleteAllCartsByUserId([FromRoute] int userId,[FromRoute] int productId)
        {
            var result = await _cartService.DeleteProductIdInCartByUserId(userId,productId);
            return Ok(result);
        }
    }
}
