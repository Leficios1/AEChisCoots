using SWP391_BL3W.DTO.Request;
using SWP391_BL3W.DTO.Response;

namespace SWP391_BL3W.Services.Interface
{
    public interface ICartService
    {
        public Task<bool> AddProductToCartByUserId(int userId, int productId);
        public Task<bool> UpdateQuantityByProductIdAndUserId(int userId, int productId, int quantity);

        public Task<bool> CompletedPaymentCartToOrder(int userId, PaymentDTO paymentDTO); 

        public Task<bool> DeleteAllProductsInCartByUserId(int userId);
        public Task<bool> DeleteProductIdInCartByUserId(int userId, int productId);
        public Task<CartDTO[]> GetCartsByUserId (int userId);
    }
}
