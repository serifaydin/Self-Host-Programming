using System.Web.Http;

namespace CA_WebApi_SelfHost
{
    public class UserController : ApiController
    {
        [HttpGet]
        public string Get()
        {
            return "Hello Self Host";
        }

        [HttpGet]
        public string Get(string Name)
        {
            return "Hello " + Name;
        }

        [HttpPost]
        public string Post(object model)
        {
            return "success Post";
        }

        [HttpPut]
        public string Put(object model)
        {
            return "success Put";
        }

        [HttpDelete]
        public string Delete(object model)
        {
            return "success Delete";
        }
    }
}