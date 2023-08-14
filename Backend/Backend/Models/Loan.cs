namespace Backend.Models
{
    public class Loan
    {
        public int loanId { get; set; }

        public int totalPA { get; set; }

        public int remainingPA { get; set; }

        public int remainingTime { get; set; }

        public int monthlyEMI { get; set; }

        public int userId { get; set; }
    }
}
