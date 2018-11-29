using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChatApi.v1.Models;

namespace ChatApi.v1.Controllers
{
    [Route("api/v1/main/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DatabaseContext db;

        public UsersController()
        {
            db = new DatabaseContext();
        }

        // GET api/v1/main/users
        [HttpGet]
        public IEnumerable<User> Get(int? id, string login, string email, string telephoneNumber)
        {
            if (id == null && login == null && email == null && telephoneNumber == null)
                return db.User;

            var usersFromParameters = from user in db.User
                                      where (id.HasValue && user.Id == id) ||
                                      (login != null && user.Login == login) ||
                                      (email != null && user.Email == email) ||
                                      (telephoneNumber != null && user.TelephoneNumber == telephoneNumber)
                                      select user;

            return usersFromParameters;
        }

        // GET api/v1/main/users/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/v1/main/users
        [HttpPost]
        public IActionResult AddNewUser([FromBody] User user)
        {
            if (user == null)
                return BadRequest();

            var userExists = db.User.Where(u => u.Login == user.Login);

            if (userExists.Any())
                return StatusCode(403); // ERROR 403 (forbidden) user login exists in the database

            var missingIds = Enumerable.Range(1, db.User.LastOrDefault().Id + 1).Except(db.User.Select(u => u.Id));
            user.Id = missingIds.FirstOrDefault();
            user.RegistrationDate = DateTime.Now;
            db.User.Add(user);
            db.SaveChangesAsync();

            return Ok();
        }

        // PUT api/v1/main/users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/v1/main/users/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
