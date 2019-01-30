using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatServer.v1.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        // GET api/v1/default
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Welcome to Chat Api services!";
        }
    }
}