namespace Payment.Application.DTO.Response
{
    public class PaymentResponseModel
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public DateTime PaymentDate { get; set; }

        public decimal Amount { get; set; }

        public int BranchId { get; set; }
    }
}
