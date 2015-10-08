using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMP.Models
{
    public class Member
    {
        [ForeignKey("Profile")]
        public int Id { get; set; }
        public string UserName { get; set; }

        public string MemberName { get; set; }

        public DateTime Created { get; set; }
        public DateTime LastLogin { get; set; }

        public Profile Profile { get; set; }

        public ICollection<Message> Messages { get; set; }

        public ICollection<Favourite> Favourites { get; set; }
    }
    
}  