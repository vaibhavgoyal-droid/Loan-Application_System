namespace Backend.Models
{
    public class Payment
    {
        public int paymentId { get; set; }

        public int userId { get; set; }

        public int loanId { get; set; }

        public DateOnly DateTime {  get; set; }

        public int paidAmount { get; set; }
    }
}
