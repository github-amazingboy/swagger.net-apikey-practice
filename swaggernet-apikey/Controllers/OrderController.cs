using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace swaggernet_apikey.Controllers
{
    //[TokenFilter]
    [MyAuthorizeAttribute]
    public class OrderController : ApiController
    {
        public IEnumerable<string> Get()
        {
            var user = this.User.Identity as MyPrincipal;
            Console.WriteLine(user.RegisterID); 
            return new string[] { "order1", "order2" };
        }
    }
}
