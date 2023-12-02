namespace GeekShopping.Email.Messages
{
    public class UpdatePaymentResultMessage
    {
        public long Orderid { get; set; }
        public bool Status { get; set; }
        public string Email { get; set; }
    }
}
