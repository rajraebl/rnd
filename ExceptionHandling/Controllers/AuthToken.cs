using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExceptionHandling.Controllers
{
    public class AuthToken
    {
        public string Token { get; set; }

        public DateTime Expiration { get; set; }

        public User ApiUser { get; set; }
    }
}
