using Backend.Models;

namespace Backend.Repository
{
    public class LoanRequestRepo:ILoanRequestRepo
    {
        private readonly LoanRequestDBContext context;

        public LoanRequestRepo(LoanRequestDBContext context)
        {
            this.context = context;
        }

        public LoanRequest AddNewLoanRequest(LoanRequest loanRequest)
        {
            if(loanRequest.loanAmount > (loanRequest.salary * 50))
            {
                loanRequest.status = "Rejected";
            }
            else
            {
                loanRequest.status = "pending";
            }
            context.LoanRequests.Add(loanRequest);
            context.SaveChanges();
            return loanRequest;
        }

        public List<LoanRequest> GetAllLoanRequests()
        {
            return context.LoanRequests.ToList();
        }

        public LoanRequest GetLoanRequestById(int id)
        {
            return context.LoanRequests.SingleOrDefault(e => e.loanrequestId.Equals(id));
        }

        public List<LoanRequest> GetLoanRequestByUserId(int userId)
        {
            List<LoanRequest>loanrequests = new List<LoanRequest>();
            foreach(var loanRequest in context.LoanRequests)
            {
                if(loanRequest.userId == userId)
                {
                    loanrequests.Add(loanRequest);
                }
            }
            return loanrequests;
        }
        public LoanRequest RemoveLoanRequest(int id)
        {
            // string result = "";
            LoanRequest loanRequest1 = context.LoanRequests.FirstOrDefault(e => e.loanrequestId.Equals(id));
            if (loanRequest1 != null)
            {
                context.LoanRequests.Remove(loanRequest1);
                context.SaveChanges();
                return loanRequest1;
            }
            else
            {
                return loanRequest1;
            }
        }

        public LoanRequest UpdateLoanRequest(LoanRequest loanrequest)
        {
            // string result = "";
            LoanRequest loanRequest1 = context.LoanRequests.FirstOrDefault(e => e.loanrequestId.Equals(loanrequest.loanrequestId));
            if (loanRequest1 != null)
            {
                foreach (var loanrequesti in context.LoanRequests)
                {
                    if (loanrequesti.loanrequestId == loanrequest.loanrequestId)
                    {
                        loanrequesti.loanAmount = loanrequest.loanAmount;
                        loanrequesti.loanTenure = loanrequest.loanTenure;
                        loanrequesti.salary = loanrequest.salary;
                        loanrequesti.propertyAddress = loanrequest.propertyAddress;
                        loanrequesti.status = loanrequest.status;
                    }
                }
                context.SaveChanges();
                return loanRequest1;
            }
            else
            {
                return loanRequest1;
            }
        }

        public LoanRequest RejectLoanRequest(int loanrequestId)
        {
            // string result = "";
            LoanRequest loanRequest1 = context.LoanRequests.FirstOrDefault(e => e.loanrequestId.Equals(loanrequestId));
            if (loanRequest1 != null)
            {
                foreach (var loanrequesti in context.LoanRequests)
                {
                    if (loanrequesti.loanrequestId == loanrequestId)
                    {
            
                        loanrequesti.status = "Rejected";
                    }
                }
                context.SaveChanges();
                return loanRequest1;
            }
            else
            {
                return loanRequest1;
            }
        }
    }
}
