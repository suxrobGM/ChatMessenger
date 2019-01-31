using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChatServer.Models;
using ChatCore.Models;


namespace ChatServer.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public UsersController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get(int? page = 1, int? pageSize = 10)
        {
            var paginatedList = await PaginatedList<User>.CreateAsync(_db.Users, page.Value, pageSize.Value);
            return paginatedList;
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(string id, string username, string email)
        {        
            return _db.Users.Where(i => i.Id == id || i.Username == username || i.Email == email).FirstOrDefault();
        }

        // POST api/users
        [HttpPost]
        public async void Post([FromBody] User user)
        {
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
        }        

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            var user = _db.Users.Where(i => i.Id == id).FirstOrDefault();
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
        }
    }
}
