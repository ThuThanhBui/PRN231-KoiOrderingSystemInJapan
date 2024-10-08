﻿using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Service;
using KoiOrderingSystemInJapan.Service.Base;
using Microsoft.AspNetCore.Mvc;

namespace KoiOrderingSystemInJapan.APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController()
        {
            _userService ??= new UserService();
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IBusinessResult> GetUsers()
        {
            return await _userService.GetAll();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IBusinessResult> GetUser(Guid id)
        {
            var user = await _userService.GetById(id);

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IBusinessResult> PutUser(User user)
        {
            return await _userService.Save(user);
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IBusinessResult> PostUser(User user)
        {
            return await _userService.Save(user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IBusinessResult> DeleteUser(Guid id)
        {
            return await _userService.DeleteById(id);
        }
    }
}
