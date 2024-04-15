namespace SWP391_BL3W.DTO.ModelPaymentOnline
{
    public class ResponsePayment
    {
        public string? ResponseCodeMessage { get; set; }
        public string? TransactionStatusMessage { get; set; }

        public VnPayResponse? VnPayResponse { get; set; }

    }
}
