using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ChatApi.v1.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {      

        public MainController()
        {
            
        }

        // GET api/v1/main
        [HttpGet]
        public ActionResult<string> Get()
        {                                      
            return "Chat messenger server";
        }
    }
}
