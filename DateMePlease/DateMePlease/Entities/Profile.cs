using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateMePlease.Entities
{
  public class Profile
  {
    public int Id { get; set; }

    public string LookingFor { get; set; }
    public string Introduction { get; set; }
    public string Pitch { get; set; }

    public virtual Member Member { get; set; }

    public virtual Demographics Demographics { get; set; }

    public virtual ICollection<Interest> Interests { get; set; }
    public virtual ICollection<Photo> Photos { get; set; }
  }
}
