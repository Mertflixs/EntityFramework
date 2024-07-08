using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ppr_Entity.Data;
using Ppr_Entity.Entity;

namespace Ppr_Entity.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context) {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllUser() {
            var user = await _context.Users.ToListAsync();

            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<User>>> GetUser(int id) {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return BadRequest("User not found!");
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser([FromBody] User users) {
            _context.Users.Add(users);
            await _context.SaveChangesAsync();
            return Ok(await GetAllUser());
        }

        [HttpPut]
        public async Task<ActionResult<List<User>>> UpdateUser([FromBody] User user) {
            var _user = await _context.Users.FindAsync(user.Id);
            if (_user == null)
                return BadRequest("User Updated Fail. (User Not Fount)");
            _user.Name = user.Name;
            _user.FirstName = user.FirstName;
            _user.LastName = user.LastName;
            _user.Place = user.Place;

            await _context.SaveChangesAsync();
            return Ok(await _context.Users.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<User>>> DeleteUser(int id) {
            var _user = await _context.Users.FindAsync(id);
            if (_user == null)
                return BadRequest("User delete Fail. (User not found)");
            _context.Users.Remove(_user);
            await _context.SaveChangesAsync();
            return Ok(await _context.Users.ToListAsync());
        }
    }
}