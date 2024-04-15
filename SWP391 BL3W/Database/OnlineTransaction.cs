namespace SWP391_BL3W.Database
{
    public class OnlineTransaction
    {
        public string? BankTranNo { get; set; }
        public string? PayDate { get; set; }
        public string? OrderInfo { get; set; }
        public string? ResponseCode { get; set; }
        public string? TransactionId { get; set; }
        public string? TransactionStatus { get; set; }
        public string? CardType { get; set; }
        public string? TxnRef { get; set; }
        public long Amount { get; set; }
        public string? BankCode { get; set; }
        public int OrderId { get; set; }
        public int UserId { get; set; }
    }
}
