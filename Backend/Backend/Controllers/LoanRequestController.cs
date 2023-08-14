using Backend.Models;
using Backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoanRequestController : ControllerBase
    {
        private readonly ILoanRequestRepo repository;

        public LoanRequestController(ILoanRequestRepo repo)
        {
            this.repository = repo;
        }

        [HttpGet]
        public IActionResult GetAllLoanRequests() {
            return Ok(repository.GetAllLoanRequests());
        }

        [HttpGet("GetById")]

        public IActionResult GetLoanRequestById(int id)
        {
            return Ok(repository.GetLoanRequestById(id));
        }

        [HttpGet("GetByUserId/{userId}")]

        public IActionResult GetLoanRequestByUserId(int userId)
        {
            return Ok(repository.GetLoanRequestByUserId(userId));
        }

        [HttpPost]

        public IActionResult AddNewLoanRequest([FromBody] LoanRequest loanRequest)
        {
            return Ok(repository.AddNewLoanRequest(loanRequest));
        }



        [HttpPut]

        public IActionResult UpdateLoanRequest([FromBody] LoanRequest loanRequest)
        {
            return Ok(repository.UpdateLoanRequest(loanRequest));
        }

        [HttpPut("RejectRequest/{loanrequestId}")]

        public IActionResult RejectLoanRequest(int loanrequestId)
        {
            return Ok(repository.RejectLoanRequest(loanrequestId));
        }


        [HttpDelete("{loanrequestId}")]

        public  IActionResult RemoveLoanRequest(int loanrequestId)
        {
            return Ok(repository.RemoveLoanRequest(loanrequestId));
        }
    }
}
