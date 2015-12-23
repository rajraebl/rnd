using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExceptionHandling.Controllers
{
    public class TokenRequestModel
    {
        public string ApiKey { get; set; }
        public string Signature { get; set; }
    }
}
