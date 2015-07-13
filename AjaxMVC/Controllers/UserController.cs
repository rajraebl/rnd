using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace AjaxMVC.Controllers
{
    public class UserController : ApiController
    {
        // GET api/user
        public string Get()
        {
            Thread.Sleep(1000);
            /*
            IList<User> Users = new List<User>();

            for (int i = 0; i < 10; i++)
            {
                Users.Add(new User() { Id = i, Name = "<li>User :" + i + "</li>" });
                
            }
             * */
            string Users = "<Ul><li>ola</li><li>pola</li></ul>";

            return Users;
            //return new string[] { "value1", "value2" };
        }

        // GET api/user/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/user
        public void Post([FromBody]string value)
        {
        }

        // PUT api/user/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/user/5
        public void Delete(int id)
        {
        }
    }

    public struct User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
