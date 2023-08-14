using Backend.Models;

namespace Backend.Repository
{
    public interface ILoanRequestRepo
    {
        List<LoanRequest> GetAllLoanRequests();

        LoanRequest GetLoanRequestById(int id);

        List<LoanRequest> GetLoanRequestByUserId(int userId);

        LoanRequest AddNewLoanRequest(LoanRequest loanRequest);

        LoanRequest UpdateLoanRequest(LoanRequest loanRequest);

        LoanRequest RejectLoanRequest(int loanrequestId);

        LoanRequest RemoveLoanRequest(int id);
    }
}
