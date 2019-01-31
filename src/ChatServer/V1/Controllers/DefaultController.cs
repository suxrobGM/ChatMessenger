using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatServer.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        // GET api/default
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Welcome to Chat Api services!";
        }
    }
}