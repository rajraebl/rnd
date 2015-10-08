using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DMP.Models
{
    public class DMPRepository
    {
        DMPContext db = new DMPContext();
        internal ICollection<Profile> GetRandomProfiles(int p)
        {
            return db.ProfileSet.Include("Photos").Take(p).ToList();
        }
    }
}