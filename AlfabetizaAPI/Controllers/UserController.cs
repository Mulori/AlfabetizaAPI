using AlfabetizaAPI.Models.DTO;
using AlfabetizaAPI.Models.Entities;
using AlfabetizaAPI.Repository.Interface;
using AlfabetizaAPI.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AlfabetizaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICrypto _crypto;

        public UserController(IUserRepository repository, IMapper mapper, ICrypto crypto)
        {
            _repository = repository;
            _mapper = mapper;
            _crypto = crypto;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var users = await _repository.GetAsync();

            var list_users = _mapper.Map<List<UserResume>>(users);

            return list_users != null ? Ok(list_users) : BadRequest(new { message = "No users found" });
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _repository.GetByIdAsync(id);

            return user != null ? Ok(user) : BadRequest(new { message = "No users found" });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(UserAdd userAdd)
        {
            if (userAdd == null) return BadRequest(new { message = "Incorrect Request" });

            var mapper_add = _mapper.Map<User>(userAdd);

            mapper_add.password = _crypto.MD5(userAdd.password);
            mapper_add.birth_date = userAdd.birth_date.ToUniversalTime();
            mapper_add.created_at = DateTime.Now.ToUniversalTime();
            mapper_add.updated_at = DateTime.Now.ToUniversalTime();

            _repository.Add(mapper_add);

            return await _repository.SaveChangesAsync() 
                ? Ok(new { message = "User registered successfully" }) 
                : BadRequest(new { message = "There was a problem registering the user" });
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UserUpdate userUpdate)
        {
            if (id <= 0) return BadRequest(new { message = "No user found for update with id entered" });

            var _user = await _repository.GetByIdAsync(id);

            if(_user == null) return BadRequest(new { message = "No user found for update with id entered" });

            var mapper_update = _mapper.Map(userUpdate, _user);

            //mapper_update.updated_at = DateTime.Now;

            _repository.Update(mapper_update);

            return await _repository.SaveChangesAsync() 
                ? Ok(new { message = "User registered successfully" }) 
                : BadRequest(new { message = "There was a problem registering the user" });
        }
    }
}
