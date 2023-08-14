using Backend.Models;

namespace Backend.Repository
{
    public class PaymentRepo:IPaymentRepo
    {
        private readonly PaymentDBContext context;

        private readonly LoanDBContext loanDBContext;

        private ILoanRepo loanRepo;

        public PaymentRepo(PaymentDBContext context,LoanDBContext loanDBContext,ILoanRepo loanRepo)
        {
            this.context = context;
            this.loanDBContext = loanDBContext; this.loanRepo = loanRepo;
        }

        //public PaymentRepo(LoanDBContext loanDBContext)
        //{
        //    this.loanDBContext = loanDBContext;
        //}

        //public PaymentRepo(ILoanRepo loanRepo)
        //{
        //    this.loanRepo = loanRepo;
        //}

        public Payment GetPaymentById(int id) { 
            return context.Payments.SingleOrDefault(e => e.paymentId.Equals(id));
        }

        public List<Payment> GetPaymentByuserId(int userId)
        {
            List<Payment> result = new List<Payment>();
            Payment payment = context.Payments.FirstOrDefault(p => p.userId.Equals(userId));
            if(payment != null)
            {
                foreach(var item in context.Payments)
                {
                    if(item.userId == userId)
                    {
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        public Payment MakePayment(Payment payment)
        {
            Loan loan = loanDBContext.Loans.SingleOrDefault(e => e.loanId.Equals(payment.loanId));
            if(loan != null)
            {
                double principlePaid, interestPaid, newremainingPA;
                interestPaid = loan.remainingPA * 7 / 12;
                principlePaid = payment.paidAmount - interestPaid;
                newremainingPA = loan.remainingPA - principlePaid;
                loan.remainingPA = (int)newremainingPA;
                //monthlyEMi UPdate
                loanRepo.UpdateLoan(loan);
                context.Payments.Add(payment);
                context.SaveChanges();
            }
            return payment;
        }
    }
}
