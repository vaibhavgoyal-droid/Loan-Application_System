
using Backend.Models;
using Backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController:ControllerBase
    {
        private readonly IClientRepo repository;

        public ClientsController(IClientRepo repo)
        {
            this.repository = repo;
        }
        [HttpPost]

        public IActionResult AddNewClient([FromBody] Client client)
        {
            return Ok(repository.AddNewClient(client));
        }
        [HttpPost("login")]

        public IActionResult LoginClient([FromBody] Client client) { 
            return Ok(repository.LoginClient(client));
        }

        [HttpPut("forgotPassword")]

        public IActionResult ChangePassword([FromBody] Client client)
        {
            return Ok(repository.ChangePassword(client));
        }
    }
}
