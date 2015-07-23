using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
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
        public IList<User> Get(int id)
        {
            IList<User> Users = new List<User>();

            for (int i = 0; i < 5; i++)
            {
                Users.Add(new User() { Id = i, Name = "User :" + i + "" });

            }

            return Users;
        }

        // POST api/user
        public string Post([FromBody]string x)
        {
            string value = "";
            string y = "";
            return (string.Format("you entered: {0} and x :{1} and y : {2}", value, x, y));
        }

       
        public string Post([FromBody] cUser x, string value)
        {
            //string value = "";
            //var x = new cUser();

            return (string.Format("you entered: {0} and id :{1} and name : {2}", value, x.Id, x.Name));
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
    public class cUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
