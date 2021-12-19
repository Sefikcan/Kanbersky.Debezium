namespace Payment.Application.DTO.Request
{
    public class CreatePaymentRequestModel
    {
        public int CustomerId { get; set; }

        public DateTime PaymentDate { get; set; }

        public decimal Amount { get; set; }

        public int BranchId { get; set; }
    }
}
