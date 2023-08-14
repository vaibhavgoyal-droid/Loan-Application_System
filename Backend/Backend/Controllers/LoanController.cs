using Backend.Models;
using Backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoanController:ControllerBase
    {
        private readonly ILoanRepo repository;

        public LoanController(ILoanRepo repo)
        {
            this.repository = repo;
        }

        [HttpPost("{loanrequestId}")]

        public IActionResult AddLoan(int loanrequestId)
        {
            return Ok(repository.AddLoan(loanrequestId));
        }

        [HttpPut]
        public IActionResult UpdateLoan(Loan loan)
        {
            return Ok(repository.UpdateLoan(loan));
        }

        [HttpGet]

        public IActionResult GetAllLoans()
        {
            return Ok(repository.GetAllLoans());
        }

        [HttpGet("GetByUserId/{userId}")]

        public IActionResult GetLoansByUserId(int userId)
        {
            return Ok(repository.GetLoansByUserId(userId));
        }

        [HttpGet("GetById")]

        public IActionResult GetLoanById(int id)
        {
            return Ok(repository.GetLoanById(id));  
        }

        [HttpDelete]

        public IActionResult EndLoan(int id)
        {
            return Ok(repository.EndLoan(id));
        }
    }
}
