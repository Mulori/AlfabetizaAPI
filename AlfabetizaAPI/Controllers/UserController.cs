﻿using AlfabetizaAPI.Models.DTO;
using AlfabetizaAPI.Models.Entities;
using AlfabetizaAPI.Repository.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlfabetizaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _repository.GetAsync();

            var list_users = _mapper.Map<List<UserResume>>(users);

            return list_users != null ? Ok(list_users) : BadRequest("No users found");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _repository.GetByIdAsync(id);

            return user != null ? Ok(user) : BadRequest("No users found");
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserAdd userAdd)
        {
            if (userAdd == null) return BadRequest("Incorrect Request");

            var mapper_add = _mapper.Map<User>(userAdd);

            mapper_add.created_at = DateTime.Now;
            mapper_add.updated_at = DateTime.Now;

            _repository.Add(mapper_add);

            return await _repository.SaveChangesAsync() 
                ? Ok("User registered successfully") 
                : BadRequest("There was a problem registering the user");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UserUpdate userUpdate)
        {
            if (id <= 0) return BadRequest("No user found for update with id entered");

            var _user = await _repository.GetByIdAsync(id);

            if(_user == null) return BadRequest("No user found for update with id entered");

            var mapper_update = _mapper.Map(userUpdate, _user);

            //mapper_update.updated_at = DateTime.Now;

            _repository.Update(mapper_update);

            return await _repository.SaveChangesAsync() 
                ? Ok("User registered successfully") 
                : BadRequest("There was a problem registering the user");
        }
    }
}
