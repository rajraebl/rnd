using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMP.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime MessageSent { get; set; }
        public bool Read { get; set; }

        public int RecipientId { get; set; }
        public int ParentId { get; set; }


    }
}