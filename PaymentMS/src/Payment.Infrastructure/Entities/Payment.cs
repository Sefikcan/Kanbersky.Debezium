namespace Payment.Infrastructure.Entities
{
    public class Payment
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public DateTime PaymentDate { get; set; }

        public decimal Amount { get; set; }

        public int BranchId { get; set; }
    }
}
