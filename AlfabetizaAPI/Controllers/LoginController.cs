using AlfabetizaAPI.Models.DTO;
using AlfabetizaAPI.Models.Entities;
using AlfabetizaAPI.Repository.Interface;
using AlfabetizaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AlfabetizaAPI.Controllers
{
    [ApiController]
    [Route("auth/[controller]")]
    public class LoginController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly ITokenServices _tokenService;
        private readonly ICrypto _crypto;
        public LoginController(IUserRepository repository, ITokenServices tokenService, ICrypto crypto)
        {
            _tokenService = tokenService;
            _repository = repository;
            _crypto = crypto;
        }

        [HttpPost]
        public async Task<ActionResult<dynamic>> Authenticate(UserLogin _user)
        {
            var user = await _repository.GetByEmailAndPasswordAsync(_user.email, _crypto.MD5(_user.password));

            if (user == null)
                return NotFound(new { message = "Incorrect email or password" });

            var token = _tokenService.GenerateToken(user);

            return Ok(new { username = user.name, token = token });
        } 
    }
}
