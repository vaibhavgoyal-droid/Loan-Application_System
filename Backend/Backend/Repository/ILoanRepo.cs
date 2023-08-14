using Backend.Models;

namespace Backend.Repository
{
    public interface ILoanRepo
    {
        List<Loan> GetAllLoans();

        List<Loan> GetLoansByUserId(int userId);

        Loan GetLoanById(int id);

        Loan AddLoan(int loanrequestId);

        Loan UpdateLoan(Loan loan);

        Loan EndLoan(int loanrequestId);
    }
}
