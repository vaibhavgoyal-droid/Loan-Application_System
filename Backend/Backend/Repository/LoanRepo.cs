using Backend.Models;

namespace Backend.Repository
{
    public class LoanRepo : ILoanRepo
    {
        private readonly LoanDBContext context;

        private readonly LoanRequestDBContext loanRequestDBContext;

        private ILoanRequestRepo loanrequestRepo;

        public LoanRepo(LoanDBContext context,LoanRequestDBContext loanRequestDBContext,ILoanRequestRepo loanRequestRepo)
        {
            this.context = context;
            this.loanRequestDBContext = loanRequestDBContext;
            this.loanrequestRepo = loanRequestRepo;
        }
        double calculateEMI(int amount, double interestRate, double tenure)
        {
            double emi = (amount * interestRate * (Math.Pow((1 + interestRate), tenure))) / (Math.Pow((1 + interestRate), tenure) - 1);
            return emi;
        }
        public Loan AddLoan(int loanrequestId)
        {
            LoanRequest loanRequest = loanRequestDBContext.LoanRequests.SingleOrDefault(e => e.loanrequestId.Equals(loanrequestId));
            Loan loan = new Loan();
            if (loanRequest != null)
            {
                loan.totalPA = loanRequest.loanAmount;
                loan.remainingPA = loanRequest.loanAmount;
                loan.remainingTime = loanRequest.loanTenure;
                double emi = calculateEMI(loanRequest.loanAmount, 0.07 / 12.0, loanRequest.loanTenure * 12);
                loan.monthlyEMI = (int)emi;
                loan.userId = loanRequest.userId;
                loanRequest.status = "Approved";
                context.Loans.Add(loan);
                loanRequestDBContext.SaveChanges();
                context.SaveChanges();
            }
            return loan;
        }

        public List<Loan> GetAllLoans()
        {
            return context.Loans.ToList();
        }

        public Loan UpdateLoan(Loan loan)
        {
            Loan loan1 = context.Loans.FirstOrDefault(e => e.loanId.Equals(loan.loanId)); 
            if(loan1 != null)
            {
                foreach (var item in context.Loans)
                {
                    if (item.loanId == loan.loanId)
                    {
                        //item.totalPA = loan.totalPA;
                        item.remainingPA = loan.remainingPA;
                        item.monthlyEMI = loan.monthlyEMI;
                    }
                }
                context.SaveChanges();
            }
            return loan;
        }

        public Loan EndLoan(int loanrequestId)
        {
            Loan loan1 = context.Loans.FirstOrDefault(e => e.loanId.Equals(loanrequestId));
            if(loan1 != null)
            {
                context.Loans.Remove(loan1);
                context.SaveChanges();
            }
            return loan1;
        }

        public List<Loan> GetLoansByUserId(int userId)
        {
            List<Loan>loansById = new List<Loan>();
            foreach(var item in context.Loans)
            {
                if(item.userId == userId)
                {
                    loansById.Add(item);
                }
            }
            return loansById;
        }

        public Loan GetLoanById(int id)
        {
            return context.Loans.SingleOrDefault(e => e.loanId.Equals(id));
        }
    }
}
