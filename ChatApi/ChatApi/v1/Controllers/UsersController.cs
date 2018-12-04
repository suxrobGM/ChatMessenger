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
        public UsersController()
        {
            
        }

        // GET api/v1/main/users
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get(int? id, string username, string email, string telephoneNumber)
        {            
            using (var db = new DatabaseContext())
            {
                if (id == null && username == null && email == null && telephoneNumber == null)
                    return db.Users.ToList();

                var usersFromParameters = from user in db.Users
                                          where (id.HasValue && user.Id == id) ||
                                          (username != null && user.Username == username) ||
                                          (email != null && user.Email == email) ||
                                          (telephoneNumber != null && user.TelephoneNumber == telephoneNumber)
                                          select user;

                return usersFromParameters.ToList();
            }       
        }

        // GET api/v1/main/users/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            using (var db = new DatabaseContext())
            {
                return db.Users.Where(u => u.Id == id).FirstOrDefault();
            }      
        }

        // POST api/v1/main/users
        [HttpPost]
        public IActionResult AddNewUser([FromBody] User user)
        {
            using (var db = new DatabaseContext())
            {
                if (user == null)
                    return BadRequest();

                var userExists = db.Users.Where(u => u.Username == user.Username);

                if (userExists.Any())
                    return StatusCode(403); // ERROR 403 (forbidden) such username exists in the database

                var missingIds = Enumerable.Range(1, db.Users.LastOrDefault().Id + 1).Except(db.Users.Select(u => u.Id));
                user.Id = missingIds.FirstOrDefault();
                user.RegistrationDate = DateTime.Now;
                db.Users.Add(user);
                db.SaveChangesAsync();

                return Ok();
            }        
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
