using Backend.Models;
using Backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("controller")]
    public class PaymentController:ControllerBase
    {
        private readonly IPaymentRepo repository;

        public PaymentController(IPaymentRepo repo)
        {
            this.repository = repo;
        }

        [HttpGet("GetById")]
        public IActionResult GetPaymentById(int id)
        {
            return Ok(repository.GetPaymentById(id));
        }

        [HttpGet("GetByUserId")]

        public IActionResult GetPaymentByuserId(int userId)
        {
            return Ok(repository.GetPaymentByuserId(userId));
        }

        [HttpPost]

        public IActionResult MakePayment(Payment payment)
        {
            return Ok(repository.MakePayment(payment));
        }
    }
}
