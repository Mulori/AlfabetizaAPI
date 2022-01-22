using AlfabetizaAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AlfabetizaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        public readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = _repository.Get();
            return users.Any() ? Ok(users) : BadRequest("No users found");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _repository.GetById(id);
            return user != null ? Ok(user) : BadRequest("No users found");
        }
    }
}
