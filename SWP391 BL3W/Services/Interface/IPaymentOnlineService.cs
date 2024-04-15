using SWP391_BL3W.DTO.ModelPaymentOnline;

namespace SWP391_BL3W.Services.Interface
{
    public interface IPaymentOnlineService
    {

        public Task<string> CallAPIPayByUserId(int userId);
        public Task<ResponsePayment> GetInformationPayment(string urlResponse);
    }
}
