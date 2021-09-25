using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


// [3insys]
// boilerplate VS "New API COntroller"
// added 2 end points DoError and DoValid
// DoError: fails everytime (divide by 0)
// DoValid: Always successful


namespace POCWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            if (id == 0)
            {
                return (22 / id).ToString();
            }
            return "value";
        }


        // Force Error
        [Route("DoError")]
        [HttpGet]
        public string DoError()
        {
            int divisor = 0;
            return (42 / divisor).ToString();
        }

        // Simple test end point
        [HttpGet]
        [Route("DoValid")]
        public string DoValid()
        {
            return "Valid call";
        }

    }
}