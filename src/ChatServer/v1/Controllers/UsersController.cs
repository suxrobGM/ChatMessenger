﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChatServer.Models;
using ChatCore.Models;


namespace ChatServer.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public UsersController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET api/v1/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get(int pageIndex = 1, int pageSize = 10)
        {
            var paginatedList = await PaginatedList<User>.CreateAsync(_db.Users.AsNoTracking(), pageIndex, pageSize);
            return paginatedList;
        }

        // GET api/v1/users/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/v1/users
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/v1/users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/v1/users/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
