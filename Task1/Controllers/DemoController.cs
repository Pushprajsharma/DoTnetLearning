using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2.Controllers
{
    public class DemoController : ApiController
    {
        static List<string> myStr = new List<string> { "a", "b", "c", "d" };


        public IEnumerable<string> Get() 
        {
            return myStr;
        }

        public IEnumerable<string> Post([FromBody] string val) 
        {

            myStr.Add(val);
            return myStr;
        }

        public IEnumerable<string> Put(int id, [FromBody] string val) 
        {
            myStr[id - 1] = val;
            return myStr;
        }

    }
}
